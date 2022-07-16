using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.FileHandlers
{
    internal class FileWriter : FileWrapper
    {
        public FileWriter() : base() { }
        public FileWriter(string filename) : base(filename) { }

        public void Write(string text) => File.WriteAllText(FilePath, text);
        public void WriteLines(object[] content)
        {
            using (var sw = new StreamWriter(FilePath))
            {
                foreach (var item in content)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}
