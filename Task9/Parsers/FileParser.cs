using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Parsers
{
    internal abstract class FileParser
    {
        public string FilePath { get; init; }

        public FileParser() { }
        public FileParser(string filename)
        {
            string assets = @"../../../assets";
            FilePath = Path.GetFullPath(Path.Combine(assets, filename));

            if (!File.Exists(FilePath))
                throw new FileNotFoundException($"Could not find file: {FilePath}.");
        }
    }
}