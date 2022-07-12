using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.FileHandlers
{
    internal class DictionaryParser : FileReader
    {
        public DictionaryParser() : base() { }
        public DictionaryParser(string filename) : base(filename) { }

        public Dictionary<string, string> Parse()
        {
            var dict = new Dictionary<string, string>();

            using (var sr = new StreamReader(FilePath))
            {
                string? line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(" - ");
                    dict.Add(parts[0], parts[1]);
                }
            }
            return dict;
        }
    }
}
