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
                sw.Write(em);
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
    }
}
