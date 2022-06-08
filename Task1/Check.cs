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
        private int _tableWidth;

        public Check() { }
        public Check(Buy buy) : this(buy, 100) { }
        public Check(Buy buy, int tableWidth)
        {
            _buy = buy;
            _tableWidth = FixTableWidth(tableWidth);
        }

        #region Object methods



        #endregion


        #region Methods

        public void DisplayInfo()
        {
            PrintSeparator();

            PrintRow("Id", "Name", "Price", "Weight");

            foreach (var item in _buy)
            {
                var (id, name, price, weight) = item.product;

                PrintRow(id, name, price, weight);
            }
        }

        private void PrintRow(params object[] args)
        {
            string[] columns = args.Select(x => x.ToString()).ToArray();

            int colWidth = (_tableWidth - columns.Length - 1) / columns.Length;

            var row = new StringBuilder("|");
            foreach (string col in columns)
            {
                row.Append(Center(col, colWidth));
                row.Append("|");
            }

            Console.WriteLine(row.ToString());
            PrintSeparator();
        }
        private void PrintSeparator()
        {
            Console.WriteLine(new string('-', _tableWidth));
        }
        private string Center(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string('-', width);
            }

            if (text.Length > width)
            {
                return text.Substring(0, width);
            }
            else
            {
                return text.PadLeft(text.Length + (width - text.Length) / 2).PadRight(width);
            }
        }

        private int DetermineNumberOfColumns()
        {
            return typeof(Product).GetProperties().Length;
        }

        private int FixTableWidth(int tableWidth)
        {
            int numOfCols = DetermineNumberOfColumns();

            // Calculate column width.
            int colWidth = (int)Math.Ceiling((double)(tableWidth - numOfCols - 1) / numOfCols);

            // Increase table width to accommodate column length.
            int fixedWidth = numOfCols + 1 + colWidth * numOfCols;

            return fixedWidth;
        }

        #endregion



    }
}