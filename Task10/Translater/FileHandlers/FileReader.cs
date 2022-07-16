using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.FileHandlers
{
    internal class FileReader : FileWrapper
    {
        public FileReader() : base() { }
        public FileReader(string filename) : base(filename)
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"Could not find file: {FilePath}.");
        }

        public string Read() => File.ReadAllText(FilePath);
        public string[] ReadLines() => File.ReadAllLines(FilePath);
    }
}
