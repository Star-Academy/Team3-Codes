
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace phase4.Model
{
    class Reader
    {
        public List<T> Read<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}