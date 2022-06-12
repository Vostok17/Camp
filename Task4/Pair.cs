
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Pair
    {
        public int Number { get; set; }
        public int Frequency { get; set; }

        public Pair(int number, int frequancy)
        {
            Number = number;
            Frequency = frequancy;
        }
        public override string ToString()
        {
            return $"<Key {Number}, Value {Frequency}>";
        }
    }
}