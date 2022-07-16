using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.FileHandlers
{
    internal class FileWrapper
    {
        public string? FilePath { get; set; }

        public FileWrapper() { }
        public FileWrapper(string filename)
        {
            string assets = @"../../../assets";
            FilePath = Path.GetFullPath(Path.Combine(assets, filename));
        }
    }
}
