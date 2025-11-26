using System;
using System.IO;
using System.Text.Json;
using LiteDB;

namespace BlitzPatch
{
    internal static class LiteDbJsonImporter
    {
        public static void ConvertJsonToLiteDb(string jsonPath, string outputDbPath, bool overwrite = false)
        {
            if (string.IsNullOrWhiteSpace(jsonPath))
                throw new ArgumentException("jsonPath is null or empty", nameof(jsonPath));

            if (string.IsNullOrWhiteSpace(outputDbPath))
                throw new ArgumentException("outputDbPath is null or empty", nameof(outputDbPath));

            if (!File.Exists(jsonPath))
                throw new FileNotFoundException("JSON file not found", jsonPath);

            if (File.Exists(outputDbPath))
            {
                if (!overwrite)
                {
                    throw new IOException(
                        $"Output file '{outputDbPath}' already exists. Delete it or call with overwrite = true.");
                }

                File.Delete(outputDbPath);
            }

            string jsonText = File.ReadAllText(jsonPath);

            using (var doc = JsonDocument.Parse(jsonText))
            using (var db = new LiteDatabase($"Filename={outputDbPath};"))
            {
                if (doc.RootElement.ValueKind != JsonValueKind.Object)
                    throw new InvalidDataException("Top-level JSON must be an object of collections.");

                foreach (var property in doc.RootElement.EnumerateObject())
                {
                    var collectionName = property.Name;
                    if (property.Value.ValueKind != JsonValueKind.Array)
                    {
                        Console.WriteLine($"Warning: property '{collectionName}' is not an array. Skipping.");
                        continue;
                    }

                    var col = db.GetCollection(collectionName);
                    int inserted = 0;

                    foreach (var element in property.Value.EnumerateArray())
                    {
                        string raw = element.GetRawText();
                        var bsonValue = LiteDB.JsonSerializer.Deserialize(raw);

                        if (!bsonValue.IsDocument)
                        {
                            Console.WriteLine($"Warning: item in '{collectionName}' is not an object. Skipping.");
                            continue;
                        }

                        col.Insert(bsonValue.AsDocument);
                        inserted++;
                    }

                    Console.WriteLine($"Collection '{collectionName}': inserted {inserted} documents.");
                }
            }

            Console.WriteLine($"Done. LiteDB created at: {outputDbPath}");
        }
    }
}
