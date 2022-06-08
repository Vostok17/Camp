using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class FileHandler
    {
        private string _path;

        public FileHandler() : this(null) { }
        public FileHandler(string filename) 
        {
            if (filename != null)
            {
                // Relative path to project directory.
                string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

                _path = Path.Combine(dir, "assets", filename.Trim());
            }
        }


    }
}
