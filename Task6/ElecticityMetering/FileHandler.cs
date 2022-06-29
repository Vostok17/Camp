using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Task6
{
    internal class FileHandler
    {
        private string? _path;

        public FileHandler() { }
        public FileHandler(string filename)
        {
            if (filename != null)
            {
                // Relative path to project directory.
                string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

                _path = Path.Combine(dir, "assets", filename.Trim());
            }
        }

        #region Object methods

        public override string ToString()
        {
            return string.Format("Operates on: {0}", _path);
        }

        #endregion

        #region Methods

        public void SaveToJson(ElectricityMetering em)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };
                string data = JsonSerializer.Serialize(em, options);
                sw.Write(data);
            }
        }
        public void SaveToFile(ElectricityMetering em)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.WriteLine("Quarter: {0}", em.Quarter);
                sw.WriteLine("Number of flats: {0}", em.FlatsCount);

                var rows = em.Flats.Select(x =>
                    new
                    {
                        Number = x.Number,
                        Owner = x.Owner,
                        StartDate = x.StartDate.ToShortDateString(),
                        StartValue = x.StartValue,
                        EndDate = x.EndDate.ToShortDateString(),
                        EndValue = x.EndValue
                    }).ToArray();

                Table table = new Table(rows);
                sw.Write(table);

                sw.WriteLine($"{(DateTime.Now - em.Flats[0].EndDate).Days} days ago.");
            }
        }
        public ElectricityMetering? Read()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                string data = sr.ReadToEnd();

                ElectricityMetering? em = JsonSerializer.Deserialize<ElectricityMetering>(data);
                return em;
            }
        }

        #endregion
    }
}
