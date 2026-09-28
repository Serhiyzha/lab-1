using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace StudentApp.DataAccess.Repositories
{
    public class JsonFileRepository<T> : IRepository<T>
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        public void SaveToFile(string filePath, List<T> data)
        {
            string jsonString = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(filePath, jsonString);
        }

        public List<T> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonString, _options) ?? new List<T>();
        }
    }
}