using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using NestTest.Model;

namespace NestTest.Model
{
    public class JsonReader
    {
        public List<Person> Read(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Person>>(json);
        }
    }
}