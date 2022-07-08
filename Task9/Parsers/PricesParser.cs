using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMenu.Parsers;

namespace RestaurantMenu.Parsers
{
    internal class PricesParser : FileParser
    {
        public PricesParser() : base() { }
        public PricesParser(string filename) : base(filename) { }

        public List<(string Name, int Price)> Parse()
        {
            var priceList = new List<(string Name, int Price)>();

            using (var sr = new StreamReader(FilePath))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(" - ");
                    priceList.Add((Name: parts[0], Price: int.Parse(parts[1])));
                }
            }
            return priceList;
        }
    }
}
