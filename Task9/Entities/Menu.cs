using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMenu.Parsers;
using RestaurantMenu.UserInfo;

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

        public void CalculateCost()
        {
            string currency = UserDialog.AskAboutTheCurrency();
            Dictionary<string, double> currencyDict = new CourseParser("Course.txt").Parse();

            double currencyVal = currencyDict.ContainsKey(currency) ? currencyDict[currency] : 1;

            List<(string Name, int Price)> priceList = new PricesParser("Prices.txt").Parse();

            var ingredients = Dishes
                .SelectMany(d => d.Ingredients)
                .GroupBy(i => i, (key, g) => (key.Name, Weight: g.Sum(x => x.Weight)));

            HandleMismatch(ingredients.Select(i => i.Name).ToArray(), priceList);

            var ingredientsCost = from p in priceList
                                  join i in ingredients on p.Name equals i.Name
                                  select new
                                  {
                                      p.Name,
                                      i.Weight,
                                      p.Price,
                                      Cost = p.Price / currencyVal * (i.Weight / 1000d)
                                  };

            string[] columnNames = { "Name", "Weight", "Price (UAH)", "Cost (" + currency + ")" };
            Table table = new Table(ingredientsCost.ToArray(), columnNames);

            File.WriteAllText(@"../../../assets/Result.txt", table.ToString());
        }
        private void HandleMismatch(string[] ingredients, List<(string Name, int Price)> priceList)
        {
            var mismatch = ingredients.Except(priceList.Select(p => p.Name));

            foreach (string ingredient in mismatch)
            {
                try
                {
                    throw new Exception($"No price for {ingredient}.");
                }
                catch (Exception ex)
                {
                    UserDialog.Display(ex.Message);
                    if (!int.TryParse(UserDialog.SetThePrice(ingredient), out int price))
                    {
                        throw;
                    }
                    priceList.Add((ingredient, price));
                    File.AppendAllText(@"../../../assets/Prices.txt", $"\n{ingredient} - {price}");
                }               
            }
        }

        #endregion
    }
}
