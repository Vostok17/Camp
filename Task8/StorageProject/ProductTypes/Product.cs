using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Product : IEquatable<Product>
    {
        #region Fields and props

        public int? Id { get; init; }
        public string Name { get; init; }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            init
            {
                if (value <= 0)
                    throw new ArgumentException("Price must be greater than zero.");
                _price = value;
            }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Weight must be greater than zero.");
                _weight = value;
            }
        }

        #endregion

        public Product() { }
        public Product(int id, string name, decimal price, double weight)
        {
            Id = id;
            Name = name;
            Price = price;
            Weight = weight;
        }

        #region Object methods

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}, Weight: {Weight}.";
        }

        public override bool Equals(object? obj) => Equals(obj as Product);
        public override int GetHashCode() => Name.GetHashCode();

        #endregion

        public virtual void ChangePrice(double percentage)
        {
            _price += _price * (decimal)percentage / 100;
        }

        public void Deconstruct(out int? id, out string name, out decimal price, 
            out double weight)
        {
            id = Id;
            name = Name;
            price = _price;
            weight = _weight;
        }

        public bool Equals(Product? other)
        {
            if (other is null)
                return false;

            return Name == other.Name;
        }

        public static bool operator ==(Product p1, Product p2)
            => p1.Equals(p2);
        public static bool operator !=(Product p1, Product p2)
            => !p1.Equals(p2);
    }
}
