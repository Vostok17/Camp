using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMenu.Parsers;

namespace RestaurantMenu.Entities
{
    internal class Menu
    {
        public List<Dish> Dishes { get; set; }

        public Menu() { }
        public Menu(List<Dish> dishes)
        {
            Dishes = dishes;
        }

        #region ObjectMethods

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (Dish dish in Dishes)
            {
                sb.AppendLine(dish.ToString());
            }
            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Menu other)
            {
                if (Dishes.Count != other.Dishes.Count)
                    return false;

                for (int i = 0; i < Dishes.Count; i++)
                {
                    if (!Dishes[i].Equals(other.Dishes[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion

        #region Methods

        public void DeterminePrices()
        {
            var priceList = new PricesParser("Prices.txt").Parse();

            var ingredients = Dishes
                .SelectMany(d => d.Ingredients)
                .GroupBy(i => i, (key, g) => (Name: key.Name, Weight: g.Sum(x => x.Weight)))
                .ToList();

            var ingredientsCost = from p in priceList
                       join i in ingredients on p.Name equals i.Name
                       select new
                       {
                           p.Name,
                           i.Weight,
                           p.Price,
                           Cost = p.Price * i.Weight / 1000
                       };

        
        }

        #endregion
    }
}
