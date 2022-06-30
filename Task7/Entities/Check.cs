using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Check
    {
        #region Fields

        private readonly Buy _buy;
        private StringBuilder _check;

        private readonly int _tableWidth;
        private readonly int _columnWidth;
        private bool _isEnoughSpace;

        #endregion

        #region Ctors

        public Check() { }
        public Check(Buy buy) : this(buy, 100) { }
        public Check(Buy buy, int tableWidth)
        {
            _buy = buy;
            _check = new StringBuilder();

            (_columnWidth, _tableWidth) = CalculateWidth(tableWidth);
            _isEnoughSpace = true;

            BuildTable();

            if (!_isEnoughSpace)
            {
                _check.Clear();
                int additionalSpace = 2 * DetermineNumberOfColumns();
                _check.Append(new Check(buy, _tableWidth + additionalSpace).ToString());
            }            
        }

        #endregion

        #region Object methods

        public override bool Equals(object? obj)
        {
            if (obj is Check other)
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
            return _check.ToString();
        }

        #endregion

        #region Methods

        public void BuildTable()
        {
            PrintSeparator();

            PrintRow("Id", "Name", "Price", "Weight", "Count");

            foreach (var item in _buy)
            {
                var (id, name, price, weight) = item.product;

                PrintRow(id, name, price, weight, item.count);
            }
        }

        private void PrintRow(params object[] objs)
        {
            string[] columns = objs.Select(x => x.ToString()).ToArray();

            _check.Append("|");
            foreach (string col in columns)
            {
                _check.Append(Center(col, _columnWidth));
                _check.Append("|");
            }
            _check.AppendLine();

            PrintSeparator();
        }
        private void PrintSeparator()
        {
            _check.AppendLine(new string('-', _tableWidth));
        }
        private string Center(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string('-', width);
            }

            if (text.Length > width)
            {
                _isEnoughSpace = false;
                return text.Substring(0, width);
            }
            else
            {
                return text.PadLeft(text.Length + (width - text.Length) / 2).PadRight(width);
            }
        }

        private int DetermineNumberOfColumns()
        {
            int colsForProps = typeof(Product).GetProperties().Length;
            int colForCount = 1;

            return colForCount + colsForProps;
        }
        private (int ColWidth, int TableWidth) CalculateWidth(int tableWidth)
        {
            int numOfCols = DetermineNumberOfColumns();

            // Calculate column width.
            int colWidth = (int)Math.Ceiling((double)(tableWidth - numOfCols - 1) / numOfCols);

            // Increase table width to accommodate column length.
            int fixedTableWidth = numOfCols + 1 + colWidth * numOfCols;

            return (colWidth, fixedTableWidth);
        }

        #endregion
    }
}