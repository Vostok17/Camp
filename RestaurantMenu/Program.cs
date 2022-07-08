using RestaurantMenu;
using RestaurantMenu.Entities;
using RestaurantMenu.Parsers;
using System.Text;

Menu menu = new MenuParser("Menu.txt").Parse();

menu.CalculateCost();

Console.ReadKey();