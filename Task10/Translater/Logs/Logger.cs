using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.Logs
{
    internal static class Logger
    {
        private static readonly string _path;

        static Logger()
        {
            string assets = @"../../../Logs";
            _path = Path.Combine(assets, "logs.txt");
            File.Delete(_path);
        }
        public static void Log(string message)
        {
            using (var sw = new StreamWriter(_path, append: true))
            {
                sw.WriteLine(message);
            }
        }
    }
}