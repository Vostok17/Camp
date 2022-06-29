using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.SimpleTextEditor
{
    internal class Table
    {
        #region Fields

        private string[] _legend;
        private string[,] _values;

        private int[] _columnLengths;
        private int _separatorLength;

        private const int _offset = 2;

        private StringBuilder _table = new();
        private readonly int _rowsCount;

        #endregion

        #region Ctors

        private Table() { }
        /// <summary>
        /// Pass an array of anonymous types as argument.
        /// Name anonymous type parameters as column names.
        /// </summary>
        /// <param name="data">Array of anonymous types.</param>
        public Table(object[] data)
        {
            if (data != null)
            {
                // Get legend names.
                _legend = FormLegend(data[0]);

                // Save count of rows.
                _rowsCount = data.Length;

                // Convert object array to array of string values.
                _values = FormValues(data);

                // Calculate max length of each column.
                _columnLengths = FormColumnsLengths(_values);

                // Calculate separator length.
                _separatorLength = CalculateSeparatorLength(_columnLengths);

                // Draw a table.
                Draw();
            }
        }

        #endregion

        #region Object Methods

        public override string ToString()
        {
            return _table.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Table other)
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

        #region Methods

        private int CalculateSeparatorLength(int[] columnLengths)
        {
            // Calculate max length.
            int max = columnLengths.Sum();
            int borders = columnLengths.Length + 1;
            return max + borders;
        }
        private string[] FormLegend(object line)
        {
            var legend = new List<string>();
            foreach (var prop in line.GetType().GetProperties())
            {
                legend.Add(prop.Name);
            }
            return legend.ToArray();
        }
        private string[,] FormValues(object[] data)
        {
            string[,] values = new string[data.Length, _legend.Length];

            for (int i = 0; i < data.Length; i++)
            {
                var props = data[i].GetType().GetProperties();
                for (int j = 0; j < props.Length; j++)
                {
                    values[i, j] = props[j].GetValue(data[i]).ToString();
                }
            }
            return values;
        }
        private int[] FormColumnsLengths(string[,] values)
        {
            int[] lengths = new int[_legend.Length];

            for (int i = 0; i < _legend.Length; i++)
            {
                int max = 0;
                for (int j = 0; j < _rowsCount; j++)
                {
                    if (max < values[j, i].Length)
                        max = values[j, i].Length;
                }
                lengths[i] = max > _legend[i].Length ? max : _legend[i].Length;
                lengths[i] += _offset * 2;
            }
            return lengths;
        }
        private string Center(string text, int width)
        {
            return text.PadLeft(text.Length + (width - text.Length) / 2).PadRight(width);
        }
        private void Draw()
        {
            PrintHeader();

            for (int i = 0; i < _rowsCount; i++)
            {
                _table.Append('|');
                for (int j = 0; j < _legend.Length; j++)
                {
                    _table.Append(("  " + _values[i, j]).PadRight(_columnLengths[j]));
                    _table.Append('|');
                }
                _table.AppendLine();
                PrintSeparator();
            }
        }
        private void PrintHeader()
        {
            PrintSeparator();
            _table.Append('|');
            for (int i = 0; i < _legend.Length; i++)
            {
                _table.Append(Center(_legend[i], _columnLengths[i]));
                _table.Append('|');
            }
            _table.AppendLine();
            PrintSeparator();
        }
        private void PrintSeparator() => _table.AppendLine(new string('-', _separatorLength));

        #endregion
    }
}
