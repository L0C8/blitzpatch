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
            Db db = new Db();
            // db.viewUnits();
            // 
            db.loadUnit("D:\\SteamLibrary\\steamapps\\common\\Blitzkrieg3\\Data\\User_\\a_");
            Console.ReadKey();
            // db.test("D:\\SteamLibrary\\steamapps\\common\\Blitzkrieg3\\Data\\User_\\a_");
            // Console.WriteLine();
            // Console.ReadKey();
        }
    }
}
