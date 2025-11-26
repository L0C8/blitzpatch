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
        static void Main(string[] args)
        {
            var dbPath = args != null && args.Length > 0 ? args[0] : null;

            if (string.IsNullOrWhiteSpace(dbPath))
            {
                Console.Write("Enter path to the LiteDB file: ");
                dbPath = Console.ReadLine();
            }

            LiteDb_Browser.Browse(dbPath);

            // Leave the original GUI entry point here if we want to bring it back later.
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Gui());
        }

    }
}
