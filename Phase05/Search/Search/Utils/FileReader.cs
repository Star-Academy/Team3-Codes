using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Search.Utils
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

    }
}