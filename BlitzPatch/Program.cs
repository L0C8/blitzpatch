using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlitzPatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Utils.checkdir())
            {
                Console.WriteLine("Blitzpatch 0.00");
                Console.WriteLine("[1]: Simple Patch");
                Console.WriteLine("[2]: Manual Patch");
                Console.WriteLine("[0]: Exit");
                Console.ReadKey();
                if (true)
                {
                    Utils.SimplePatch();
                } else
                {
                    Utils.ManualPatch();
                }
            } else
            {
                Console.WriteLine("Invalid Directory.\nPlace Blitzpatch.exe into the [...]\\SteamLibrary\\steamapps\\common\\Blitzkrieg3\\ directory.\n\nPress any key to close");
                Console.ReadKey();
            }
        }

        public static void simplepatch()
        {
            //load user/a
        }
    }
}
