using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMenu.Entities;

namespace RestaurantMenu.Parsers
{
    internal class MenuParser : FileParser
    {
        public MenuParser() : base() { }
        public MenuParser(string filename) : base(filename) { }

        public Menu Parse()
        {
            var dishes = new List<Dish>();

            using (var sr = new StreamReader(FilePath))
            {
                string? dishName;
                while ((dishName = sr.ReadLine()) != null)
                {
                    var ingredients = new List<Ingredient>();

                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "")
                            break;

                        string[] parts = line.Split(", ");
                        ingredients.Add(new Ingredient
                        {
                            Name = parts[0],
                            Weight = int.Parse(parts[1])
                        });
                    }

                    dishes.Add(new Dish
                    {
                        Name = dishName,
                        Ingredients = ingredients
                    });
                }
            }
            return new Menu(dishes);
        }
    }
}
