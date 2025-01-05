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
        // roughdraft, just messing around with the json stuff
        public void viewUnits()
        {

        }

        public void addUnit()
        {
            Unit unit = new Unit
            {
                exp = 0.1,
                expLvl = 0,
                id = "test",
                idOnServer = 123,
                unitOnMaps = new UnitOnMaps
                {
                    Unknown = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    },
                    Early = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    },
                    Middle = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    },
                    Late = new MapData
                    {
                        Parent = -1,
                        Pos = new Position { X = 0.0, Y = 0.0, Z = 0.0 },
                        Angle = 0.0,
                        Modes = 0
                    }
                }
            };

            string jsonString = JsonSerializer.Serialize(unit, new JsonSerializerOptions { WriteIndented = true });
            string filePath = "C:\\Users\\Zek\\source\\repos\\Blitzpatch\\BlitzPatch\\test.json";
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"JSON file created at: {filePath}");

        }

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
                            Console.WriteLine(document["j_"].ToString());
                        }
                        else
                        {
                            Console.WriteLine("No 'Units' field in this document.");
                        }
                    }
                }
            }
        }

        class Unit
        {
            public double exp { get; set; }
            public int expLvl { get; set; }
            public string id { get; set; }
            public int idOnServer { get; set; }
            public UnitOnMaps unitOnMaps { get; set; }
        }

        class UnitOnMaps
        {
            public MapData Unknown { get; set; } = new MapData();
            public MapData Early { get; set; } = new MapData();
            public MapData Middle { get; set; } = new MapData();
            public MapData Late { get; set; } = new MapData();
        }

        class MapData
        {
            public int Parent { get; set; } = -1;
            public Position Pos { get; set; } = new Position();
            public double Angle { get; set; } = 0.0;
            public int Modes { get; set; } = 0;
        }

        class Position
        {
            public double X { get; set; } = 0.0;
            public double Y { get; set; } = 0.0;
            public double Z { get; set; } = 0.0;
        }
    }
}

