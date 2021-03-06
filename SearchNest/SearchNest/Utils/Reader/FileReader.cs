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

        public string CurrentText()
        {
            return File.ReadAllText(files.Current);
        }
        public string CurrentName()
        {
            return Path.GetFileName(files.Current); 
        }

    }
}