using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal static class Logger
    {
        private static readonly string _path;

        static Logger()
        {
            string assets = @"../../../assets";
            _path = Path.Combine(assets, "logs.txt");
            File.Delete(_path);
        }
        public static void Log(string message)
        {
            using (var sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(DateTime.Now + " - " + message);
            }
        }
        public static void EditLine(int lineNum, string message)
        {
            string[] lines = File.ReadAllLines(_path);
            lines[lineNum - 1] = message;
            File.WriteAllLines(_path, lines);
        }
        public static string[] ContentAfterDate(string date)
        {
            CultureInfo provider = new CultureInfo("en-US");

            DateTime currDate;
            if (!DateTime.TryParse(date, provider, DateTimeStyles.None, out currDate))
                throw new ArgumentException("Invalid date format.");

            string[] lines = File.ReadAllLines(_path);

            var res = new List<string>();
            foreach (string item in lines)
            {
                string dateInLine = item.Split('-')[0];
                DateTime dt = DateTime.Parse(dateInLine, provider, DateTimeStyles.None);

                if (dt >= currDate)
                {
                    res.Add(item);
                }
            }
            return res.ToArray();
        }
    }
}
