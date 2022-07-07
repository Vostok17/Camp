using RestaurantMenu;
using RestaurantMenu.Entities;
using RestaurantMenu.Parsers;

Menu menu = new MenuParser("Menu.txt").Parse();

menu.DeterminePrices();

Console.WriteLine(menu);

Console.ReadKey();