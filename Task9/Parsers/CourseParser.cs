using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Parsers
{
    internal class CourseParser : FileParser
    {
        public CourseParser() { }
        public CourseParser(string filename) : base(filename) { }

        public Dictionary<string, double> Parse()
        {
            var dict = new Dictionary<string, double>();

            using (var sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(", ");
                    dict.Add(parts[0], double.Parse(parts[1]));
                }
            }
            return dict;
        }
    }
}
