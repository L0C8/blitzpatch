using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BlitzPatch
{
    internal class Db
    {

        public void loadUnit(string path)
        {
            using (var db = new LiteDatabase(path))
            {
                var collectionNames = db.GetCollectionNames(); 

                Console.WriteLine("Collections in the database:");
                foreach (var name in collectionNames)
                {
                    Console.WriteLine($"- {name}");
                    var documents = db.GetCollection(name).FindAll();
                    foreach (var document in documents)
                    {
                        if (document.ContainsKey("j_") && document["j_"].ToString().Contains("Units"))
                        {
                            var jElement = document["j_"]; 
                            Console.WriteLine(jElement.ToString());
                        }
                    }
                }
            }
        }
    }
}

