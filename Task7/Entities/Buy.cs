using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Buy : IEnumerable<(Product product, int count)>
    {
        private List<(Product Product, int Count)> _basket = new();
        private int _totalCount = 0;

        public Buy() { }
        public Buy(List<Product> list) : this(list.ToArray()) { }
        public Buy(params Product[] products) => Add(products);

        #region Object methods

        public override bool Equals(object? obj)
        {
            if (obj is Buy other)
            {
                return ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Buy contains {0} items:", _totalCount);
            sb.AppendLine();

            foreach (var p in _basket)
            {
                sb.Append($"{p.Count} - {p.Product}");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        #endregion

        #region Methods

        public decimal TotalCost() => _basket.Sum(x => x.Count * x.Product.Price);
        public double TotalWeight() => _basket.Sum(x => x.Count * x.Product.Weight);
        public List<(Product Product, int Count)> GetListOfProducts() => _basket.ToList();
        public void Add(params Product[] products)
        {
            foreach (Product product in products)
            {
                bool isInBasket = false;
                for (int i = 0; i < _basket.Count; i++)
                    if (_basket[i].Product == product)
                    {
                        _basket[i] = (product, _basket[i].Count + 1);
                        isInBasket = true;
                        break;
                    }

                if (!isInBasket)
                    _basket.Add((product, 1));

                _totalCount++;
            }
        }
        public void Add(List<Product> list) => Add(list.ToArray());
        public void Remove(int productId, int countToRemove)
        {
            for (int i = 0; i < _basket.Count; i++)
            {
                if (_basket[i].Product.Id == productId)
                {
                    var (product, countInBasket) = _basket[i];

                    if (countInBasket > countToRemove)
                    {
                        _basket[i] = (product, countInBasket - countToRemove);
                        _totalCount -= countToRemove;
                    }
                    else
                    {
                        _basket.RemoveAt(i);
                        _totalCount -= countInBasket;
                    }
                    break;
                }
            }
        }
        public void Clear()
        {
            _basket.Clear();
            _totalCount = 0;
        }

        IEnumerator<(Product product, int count)> IEnumerable<(Product product, int count)>.GetEnumerator()
        {
            return _basket.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _basket.GetEnumerator();   
        }

        #endregion
    }
}
