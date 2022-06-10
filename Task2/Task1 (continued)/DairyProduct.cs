using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class DairyProduct : Product
    {
        public int ExpirationTermInDays { get; init; }

        public DairyProduct()
        {
            ExpirationTermInDays = 0;
        }

        public DairyProduct(int id, string name, decimal price, double weight, int expirationTermInDays)
            : base(id, name, price, weight)
        {
            ExpirationTermInDays = expirationTermInDays;
        }

        public override void ChangePrice(double percentage)
        {
            percentage += ExpirationTermInDays switch
            {
                < 20 => 15,
                < 30 => 10,
                < 60 => 5,
                _ => 0
            };
            base.ChangePrice(percentage);
        }
        public override string ToString()
        {
            return $"{base.ToString().TrimEnd('.')}, Expiration term: {ExpirationTermInDays}.";
        }
    }
}
