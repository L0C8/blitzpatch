using LiteDB;
using System;
using System.IO;

namespace BlitzPatch
{
    internal static class Db
    {
        private const string SettingsCollection = "settings";
        private const string GameDirectoryKey = "gameDirectory";
        private static readonly string SettingsDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.db");

        public static void SaveGameDirectory(string path)
        {
            try
            {
                using (var db = new LiteDatabase(SettingsDbPath))
                {
                    var col = db.GetCollection<Setting>(SettingsCollection);
                    col.Upsert(new Setting
                    {
                        Key = GameDirectoryKey,
                        Value = path,
                        UpdatedUtc = DateTime.UtcNow
                    });
                }
            }
            catch
            {
                // Persisting the setting is best-effort; ignore failures for now.
            }
        }

        public static string LoadGameDirectory()
        {
            try
            {
                if (!File.Exists(SettingsDbPath))
                {
                    return null;
                }

                using (var db = new LiteDatabase(SettingsDbPath))
                {
                    var col = db.GetCollection<Setting>(SettingsCollection);
                    var setting = col.FindById(GameDirectoryKey);
                    return setting?.Value;
                }
            }
            catch
            {
                return null;
            }
        }

        private class Setting
        {
            [BsonId]
            public string Key { get; set; }

            public string Value { get; set; }

            public DateTime UpdatedUtc { get; set; }
        }
    }
}
