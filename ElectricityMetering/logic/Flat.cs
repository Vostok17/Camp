using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.ElectricityMetering
{
    internal class Flat : IEquatable<Flat>
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

        public override bool Equals(object? obj) => Equals(obj as Flat);

        #region Object methods

        public override string ToString()
        {
            return $"Number: {Number}, Owner: {Owner}, StartDate: {StartDate.ToShortDateString()}, " +
                $"StartValue: {StartValue}, EndDate: {EndDate.ToShortDateString()}, EndValue: {EndValue}.";
        }
        public override int GetHashCode() => (Number, Owner).GetHashCode();

        public bool Equals(Flat? other)
        {
            if (other is null)
                return false;

            return Number == other.Number && Owner == other.Owner;
        }

        #endregion
    }
}
