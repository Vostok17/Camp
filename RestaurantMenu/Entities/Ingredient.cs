using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.Entities
{
    internal class Ingredient
    {
        public string Name { get; init; }
        public int Weight { get; init; }
        public decimal Price { get; set; }

        public Ingredient() { }
        public Ingredient(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        #region ObjectsMethods
        public override string ToString()
        {
            return $"{Name}, {Weight}.";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Ingredient other)
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
