using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Check
    {
        private readonly Buy _buy;

        public Check() { }
        public Check(Buy buy)
        {
            _buy = buy;
        }

        public void DisplayInfo(Buy basket)
        {
            foreach (var prod in basket.GetListOfProducts())
            {
                string formatedStr = string.Format($"{prod.Product}| Count: {prod.Count,-2}");
                Console.WriteLine(new string('-', formatedStr.Length));
                Console.WriteLine(formatedStr);
            }
            Console.WriteLine();

            Console.WriteLine("Total cost: {0:f2}", basket.TotalCost());
            Console.WriteLine("Total weight: {0:f2}", basket.TotalWeight());
        }
    }
}