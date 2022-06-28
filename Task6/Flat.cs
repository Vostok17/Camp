using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Flat
    {
        #region Props

        public int Number { get; set; }
        public string Owner { get; set; }
        public DateTime StartDate { get; set; }
        public double StartValue { get; set; }
        public DateTime EndDate { get; set; }
        public double EndValue { get; set; }

        #endregion

        public Flat() { }

        #region Object methods

        public override string ToString()
        {
            return $"Number: {Number}, Owner: {Owner}, StartDate: {StartDate.ToShortDateString()}, " +
                $"StartValue: {StartValue}, EndDate: {EndDate.ToShortDateString()}, EndValue: {EndValue}.";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Flat other)
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
