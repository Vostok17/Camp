using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class DairyProduct : Product
    {
        private int _expirationTermInDays;
        public int ExpirationTermInDays
        {
            get => _expirationTermInDays;
            init
            {
                if (_expirationTermInDays < 0)
                    throw new ArgumentOutOfRangeException(nameof(_expirationTermInDays),
                        "Expiration term must be greater than or equal to zero.");
                _expirationTermInDays = value;
            }
        }

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
            percentage += _expirationTermInDays switch
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
