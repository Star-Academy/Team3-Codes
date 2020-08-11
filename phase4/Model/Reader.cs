
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace phase4.Model
{
    class Reader<T>
    {
        public string Path { get; set; }

        public Reader(string path)
        {
            Path = path; 
        }

        public List<T> Read()
        {
            var json = File.ReadAllText(Path);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}