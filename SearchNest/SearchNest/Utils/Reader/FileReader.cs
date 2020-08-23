using System.Collections.Generic;
using System.IO;

namespace SearchNest.Utils.Reader
{
       public class FileReader : IReader
    {
        private readonly IEnumerator<string> files;

        public FileReader(string directoryPath)
        {
            files = ((IEnumerable<string>)Directory.GetFiles(directoryPath)).GetEnumerator();
        } 
        
        public bool MoveNext()
        {
            return files.MoveNext();
        }

        public string Current()
        {
            return File.ReadAllText(files.Current);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}