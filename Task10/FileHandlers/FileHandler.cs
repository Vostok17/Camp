using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.FileHandlers
{
    internal class FileHandler
    {
        private readonly string _path;

        public FileHandler() { }
        public FileHandler(string filename)
        {
            string assets = @"../../../assets";
            _path = Path.GetFullPath(Path.Combine(assets, filename));
        }

        public string Read()
        {
            return File.ReadAllText(_path);
        }
        public void Write(object[] data)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}
