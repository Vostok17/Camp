using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.UserInfo
{
    internal static class UserDialog
    {
        public static string AskAboutTheCurrency()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Please, select the currency: ");
            Console.WriteLine("[0] - UAH");
            Console.WriteLine("[1] - $");
            Console.WriteLine("[2] - €");

            string currency = Console.ReadLine();

            return currency switch
            {
                "0" => "UAH",
                "1" => "$",
                "2" => "€",
                _ => throw new Exception("Invalid option.")
            };
        }
        public static string SetThePrice(string ingredient)
        {
            Console.WriteLine($"Please, set the price for {ingredient} in UAH: ");
            return Console.ReadLine();
        }
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
