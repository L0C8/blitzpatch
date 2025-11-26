using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LiteDB;

namespace BlitzPatch
{
        public static class LiteDb_Browser
        {
            public static void Browse(string dbPath)
            {
                if (string.IsNullOrWhiteSpace(dbPath))
                {
                    Console.WriteLine("No database path provided.");
                    return;
                }

                if (!File.Exists(dbPath))
                {
                    Console.WriteLine("File not found: " + dbPath);
                    return;
                }

                try
                {
                    var connectionString = $"Filename={dbPath};Mode=ReadOnly;";

                    using (var db = new LiteDatabase(connectionString))
                    {
                        RunMainMenu(db, dbPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to open LiteDB file:");
                    Console.WriteLine(ex.Message);
                }
            }

            private static void RunMainMenu(LiteDatabase db, string dbPath)
            {
                while (true)
                {
                    Console.Clear();
                    WriteHeader("LiteDB Browser");
                    Console.WriteLine("File: " + dbPath);
                    Console.WriteLine();

                    var collections = db.GetCollectionNames()
                                        .OrderBy(n => n)
                                        .ToList();

                    if (collections.Count == 0)
                    {
                        Console.WriteLine("No collections found.");
                        Console.WriteLine();
                        Console.WriteLine("[Q] Quit");
                    }
                    else
                    {
                        Console.WriteLine("Collections:");
                        Console.WriteLine("-----------");

                        for (int i = 0; i < collections.Count; i++)
                        {
                            string name = collections[i];
                            int count = GetCollectionCount(db, name);
                            Console.WriteLine($"[{i}] {name}  (docs: {count})");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Commands:");
                        Console.WriteLine("  Type collection index (0 - {0}) and press Enter", collections.Count - 1);
                        Console.WriteLine("  J = Dump all collections as JSON");
                        Console.WriteLine("  E = Export database to JSON file");
                        Console.WriteLine("  Q = Quit");
                    }

                    Console.WriteLine();
                    Console.Write("Choice: ");
                    var input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        continue;

                    if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                        break;
                    if (input.Equals("j", StringComparison.OrdinalIgnoreCase))
                    {
                        DumpAllCollectionsJson(db, collections);
                        continue;
                    }
                    if (input.Equals("e", StringComparison.OrdinalIgnoreCase))
                    {
                        ExportDatabaseJson(db, dbPath, collections);
                        continue;
                    }

                    int index;
                    if (int.TryParse(input, out index))
                    {
                        if (index >= 0 && index < collections.Count)
                        {
                            string selectedCollection = collections[index];
                            BrowseCollection(db, selectedCollection);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index. Press any key to continue...");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Press any key to continue...");
                        Console.ReadKey(true);
                    }
                }
            }

            private static int GetCollectionCount(LiteDatabase db, string collectionName)
            {
                try
                {
                    var col = db.GetCollection(collectionName);
                    return col.Count();
                }
                catch
                {
                    return -1;
                }
            }

            private static void BrowseCollection(LiteDatabase db, string collectionName)
            {
                var col = db.GetCollection(collectionName);
                var docs = col.FindAll().ToList();

                const int pageSize = 10;
                int pageIndex = 0;
                int selectedIndex = 0;

                while (true)
                {
                    Console.Clear();
                    WriteHeader("Collection: " + collectionName);

                    if (docs.Count == 0)
                    {
                        Console.WriteLine("No documents in this collection.");
                        Console.WriteLine();
                        Console.WriteLine("[Esc] Back");
                        var keyEmpty = Console.ReadKey(true).Key;
                        if (keyEmpty == ConsoleKey.Escape)
                            return;
                        continue;
                    }

                    int totalPages = (docs.Count + pageSize - 1) / pageSize;
                    if (pageIndex >= totalPages) pageIndex = totalPages - 1;
                    if (pageIndex < 0) pageIndex = 0;

                    int start = pageIndex * pageSize;
                    int end = Math.Min(start + pageSize, docs.Count);

                    Console.WriteLine($"Documents {start} - {end - 1} of {docs.Count}");
                    Console.WriteLine($"Page {pageIndex + 1}/{totalPages}");
                    Console.WriteLine();
                    Console.WriteLine("Use Up/Down to select, Left/Right to change page.");
                    Console.WriteLine("Enter = view document, Esc = back");
                    Console.WriteLine();

                    // Clamp selectedIndex to page size
                    if (selectedIndex >= (end - start))
                        selectedIndex = end - start - 1;
                    if (selectedIndex < 0)
                        selectedIndex = 0;

                    for (int row = 0; row < end - start; row++)
                    {
                        int docIndex = start + row;
                        var doc = docs[docIndex];

                        string marker = (row == selectedIndex) ? "->" : "  ";
                        string idPreview = GetIdPreview(doc);
                        string shortPreview = Truncate(JsonPreview(doc), 80);

                        Console.WriteLine($"{marker} [{docIndex}] _id={idPreview}  {shortPreview}");
                    }

                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex--;
                            if (selectedIndex < 0)
                                selectedIndex = (end - start) - 1;
                            break;

                        case ConsoleKey.DownArrow:
                            selectedIndex++;
                            if (selectedIndex >= (end - start))
                                selectedIndex = 0;
                            break;

                        case ConsoleKey.LeftArrow:
                            pageIndex--;
                            if (pageIndex < 0)
                                pageIndex = 0;
                            selectedIndex = 0;
                            break;

                        case ConsoleKey.RightArrow:
                            pageIndex++;
                            if (pageIndex >= totalPages)
                                pageIndex = totalPages - 1;
                            selectedIndex = 0;
                            break;

                        case ConsoleKey.Enter:
                            int selectedDocIndex = start + selectedIndex;
                            if (selectedDocIndex >= 0 && selectedDocIndex < docs.Count)
                            {
                                ShowDocumentDetail(docs[selectedDocIndex], collectionName, selectedDocIndex);
                            }
                            break;

                        case ConsoleKey.Escape:
                            // Back to main menu
                            return;
                    }
                }
            }

            private static void DumpAllCollectionsJson(LiteDatabase db, List<string> collections)
            {
                Console.Clear();
                WriteHeader("Full Database JSON (read-only)");
                Console.WriteLine("This will print every document. Press Q at any prompt to stop.");
                Console.WriteLine();

                foreach (var name in collections)
                {
                    Console.WriteLine($"Collection: {name}");
                    Console.WriteLine("[");

                    var col = db.GetCollection(name);
                    bool first = true;
                    foreach (var doc in col.FindAll())
                    {
                        if (!first) Console.WriteLine(",");
                        Console.WriteLine(JsonSerializer.Serialize(doc, pretty: true, writeBinary: false));
                        first = false;
                    }

                    Console.WriteLine("]");
                    Console.WriteLine();
                    Console.WriteLine("Press Q to stop dump, any other key to continue...");

                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
                    {
                        return;
                    }

                    Console.Clear();
                    WriteHeader("Full Database JSON (read-only)");
                }

                Console.WriteLine("End of database. Press any key to return to menu.");
                Console.ReadKey(true);
            }

            private static void ExportDatabaseJson(LiteDatabase db, string dbPath, List<string> collections)
            {
                var directory = Path.GetDirectoryName(dbPath) ?? Directory.GetCurrentDirectory();
                var baseName = Path.GetFileNameWithoutExtension(dbPath);
                var exportPath = Path.Combine(directory, $"{baseName}_export.json");

                if (WriteDatabaseJson(db, collections, exportPath))
                {
                    Console.WriteLine($"Export complete: {exportPath}");
                }
                else
                {
                    Console.WriteLine("Export failed.");
                }

                Console.WriteLine("Press any key to return to menu.");
                Console.ReadKey(true);
            }

            private static bool WriteDatabaseJson(LiteDatabase db, List<string> collections, string exportPath)
            {
                try
                {
                    using (var writer = new StreamWriter(exportPath, false, new UTF8Encoding(false)))
                    {
                        writer.WriteLine("{");

                        for (int i = 0; i < collections.Count; i++)
                        {
                            var name = collections[i];
                            var col = db.GetCollection(name);

                            writer.WriteLine($"  \"{name}\": [");

                            bool firstDoc = true;
                            foreach (var doc in col.FindAll())
                            {
                                if (!firstDoc) writer.WriteLine(",");
                                var json = JsonSerializer.Serialize(doc, pretty: true, writeBinary: false);
                                writer.Write(IndentJson(json, "    "));
                                firstDoc = false;
                            }

                            writer.WriteLine();
                            writer.Write("  ]");
                            if (i < collections.Count - 1) writer.Write(",");
                            writer.WriteLine();
                        }

                        writer.WriteLine("}");
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Export failed:");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            private static string IndentJson(string json, string indent)
            {
                var lines = json.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = indent + lines[i];
                }
                return string.Join(Environment.NewLine, lines);
            }

            private static string GetIdPreview(BsonDocument doc)
            {
                if (doc.ContainsKey("_id"))
                {
                    var id = doc["_id"];
                    return id != null ? id.ToString() : "null";
                }
                return "<no _id>";
            }

            private static string JsonPreview(BsonDocument doc)
            {
                return JsonSerializer.Serialize(doc, false, false);
            }

            private static void ShowDocumentDetail(BsonDocument doc, string collectionName, int index)
            {
                while (true)
                {
                    Console.Clear();
                    WriteHeader($"Document [{index}] in {collectionName}");

                    string prettyJson = JsonSerializer.Serialize(doc, pretty: true, writeBinary: false);

                    Console.WriteLine(prettyJson);
                    Console.WriteLine();
                    Console.WriteLine("[Esc] Back");

                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                        break;
                }
            }

            private static void WriteHeader(string title)
            {
                Console.WriteLine("======================================");
                Console.WriteLine(title);
                Console.WriteLine("======================================");
            }

            private static string Truncate(string text, int maxLength)
            {
                if (string.IsNullOrEmpty(text)) return text;
                if (text.Length <= maxLength) return text;
                return text.Substring(0, maxLength - 3) + "...";
            }
        }
    }
