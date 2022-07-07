using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Entities
{
    internal class Dish
    {
        public string Name { get; init; }
        public List<Ingredient> Ingredients { get; init; }

        public Dish() { }
        public Dish(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        #region ObjectMethods

        public override string ToString()
        {
            var sb = new StringBuilder(Name);
            foreach (Ingredient ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Dish other)
            {
                return Name == other.Name;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}
