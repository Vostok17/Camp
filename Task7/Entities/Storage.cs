using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Storage
    {
        private List<(Product Product, int Count)> _products = new();

        public Storage() { }
        public Storage(List<(Product, int)> products)
        {
            _products = products;
        }

        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= _products.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _products[index].Product;
            }
            set
            {
                if (index < 0 || index >= _products.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _products[index] = (value, 1);
            }
        }

        #region Methods

        public void AddProducts()
        {
            UI ui = new UI();
            var prods = ui.PopulateProducts();

            foreach (var prod in prods)
            {
                bool isInStorage = false;
                for (int i = 0; i < _products.Count; i++)
                {
                    if (prod.Product == _products[i].Product)
                    {
                        _products[i] = (prod.Product, prod.Count + _products[i].Count);
                        isInStorage = true;
                    }
                }
                if (!isInStorage)
                    _products.Add(prod);
            }
        }
        public void Remove(int productId, int countToRemove)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Product.Id == productId)
                {
                    var (product, countInStorage) = _products[i];

                    if (countInStorage > countToRemove)
                    {
                        _products[i] = (product, countInStorage - countToRemove);
                    }
                    else
                    {
                        _products.RemoveAt(i);
                    }
                    break;
                }
            }
        }

        public List<(Meat Meat, int Count)> FindAllMeatProducts()
        {
            var meatProducts = from item in _products
                               where item.Product is Meat
                               select (item.Product as Meat, item.Count);

            return meatProducts.ToList();
        }
        public void ChangePrices(double percentage)
        {
            _products.ForEach(x => x.Product.ChangePrice(percentage));
        }

        public void ReadFromFile()
        {
            UI ui = new UI();

            bool isLoaded = false;
            do
            {
                try
                {
                    string filename = ui.AskForFilename();
                    _products = FileParser.Parse(filename);
                    isLoaded = true;
                }
                catch (FileNotFoundException ex)
                {
                    Logger.Log(ex.Message);
                }
            } while (!isLoaded);
        }

        #endregion

        #region Object methods

        public override string ToString()
        {
            int totalCount = _products.Sum(p => p.Count);

            var buffer = new StringBuilder($"Storage with {totalCount} items.\n");
            foreach (var item in _products)
            {
                buffer.AppendLine($"{item.Count} - {item.Product}");
            }
            return buffer.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Storage other)
            {
                return ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        #endregion
    }
}
