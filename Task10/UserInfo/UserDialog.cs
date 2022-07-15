using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translater.UserInfo
{
    internal static class UserDialog
    {
        public static string Ask(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Please, enter value:");
            return Console.ReadLine();
        }
    }
}
