﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Pair
    {
        public int Number { get; set; }
        public int Frequancy { get; set; }

        public Pair(int number, int frequancy)
        {
            Number = number;
            Frequancy = frequancy;
        }
        public override string ToString()
        {
            return $"Num: {Number} - {Frequancy}";
        }
    }
}
