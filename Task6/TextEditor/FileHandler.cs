using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.SimpleTextEditor
{
    internal class FileHandler
    {
        private readonly string _path;

        public FileHandler() { }
        public FileHandler(string filename)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            _path = Path.Combine(projectFolder, "assets", filename);
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
