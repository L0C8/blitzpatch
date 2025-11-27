using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlitzPatch
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Any(a => a.Equals("--cli", StringComparison.OrdinalIgnoreCase)))
            {
                RunConsoleFlow(args);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui());
        }

        private static void RunConsoleFlow(string[] args)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1) Browse a LiteDB file");
            Console.WriteLine("2) Convert JSON to LiteDB");
            Console.Write("Choice (1/2): ");
            var choice = Console.ReadLine();

            if (choice == "2")
            {
                RunJsonToLiteDb();
            }
            else
            {
                RunLiteDbBrowser(args);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static void RunLiteDbBrowser(string[] args)
        {
            var dbPath = args != null && args.Length > 0 ? args[0] : null;

            if (string.IsNullOrWhiteSpace(dbPath))
            {
                Console.Write("Enter path to the LiteDB file: ");
                dbPath = Console.ReadLine();
            }

            LiteDb_Browser.Browse(dbPath);
        }

        private static void RunJsonToLiteDb()
        {
            Console.Write("Enter path to the source JSON file: ");
            var jsonPath = Console.ReadLine();

            var defaultOutput = GetDefaultOutputPath(jsonPath);
            Console.Write($"Enter output LiteDB path (press Enter for default {defaultOutput}): ");
            var dbPath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dbPath))
            {
                dbPath = defaultOutput;
            }
            else if (IsDirectory(dbPath))
            {
                dbPath = Path.Combine(dbPath, Path.GetFileName(defaultOutput));
            }

            Console.Write("If output exists, overwrite? (y/N): ");
            var overwriteInput = Console.ReadLine();
            var overwrite = string.Equals(overwriteInput, "y", StringComparison.OrdinalIgnoreCase);

            try
            {
                LiteDbJsonImporter.ConvertJsonToLiteDb(jsonPath, dbPath, overwrite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conversion failed:");
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetDefaultOutputPath(string jsonPath)
        {
            var dir = Path.GetDirectoryName(jsonPath);
            if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir))
            {
                dir = Directory.GetCurrentDirectory();
            }

            var baseName = Path.GetFileNameWithoutExtension(jsonPath);
            if (string.IsNullOrWhiteSpace(baseName))
            {
                baseName = "output";
            }

            const string exportSuffix = "_export";
            if (baseName.EndsWith(exportSuffix, StringComparison.OrdinalIgnoreCase))
            {
                baseName = baseName.Substring(0, baseName.Length - exportSuffix.Length);
            }

            return Path.Combine(dir, baseName);
        }


        private static bool IsDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;
            if (path.EndsWith(Path.DirectorySeparatorChar.ToString()) || path.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
                return true;
            return Directory.Exists(path);
        }

    }
}
