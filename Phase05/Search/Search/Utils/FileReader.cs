using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Search.Utils
{
    public class FileReader : IReader, IEnumerator<string>
    {
        private readonly IEnumerator<string> files;

        string IEnumerator<string>.Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public FileReader(string directoryPath)
        {
            this.files = ((IEnumerable<string>)Directory.GetFiles(directoryPath)).GetEnumerator();
        } 
        
        public bool MoveNext()
        {
            return this.files.MoveNext();
        }

        public string Current()
        {
            return File.ReadAllText(files.Current);
        }

        public void Reset()
        {
            this.files.Reset();
        }

        public void Dispose()
        {
            this.files.Dispose();
        }
    }
}