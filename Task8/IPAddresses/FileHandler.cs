using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAddresses
{
    internal class FileHandler
    {
        private string _path;

        public FileHandler() { }
        public FileHandler(string filename)
        {
            string assets = @"../../../assets";
            _path = Path.GetFullPath(Path.Combine(assets, filename));
        }
        public List<(string ip, TimeOnly time, DayOfWeek day)> Read()
        {
            var data = new List<(string ip, TimeOnly time, DayOfWeek day)>();

            using (var sr = new StreamReader(_path))
            {
                // Skip header.
                sr.ReadLine();

                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(";");
                    var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), parts[2], true);
                    data.Add((parts[0], TimeOnly.Parse(parts[1]), day));
                }
            }
            return data;
        }
    }
}
