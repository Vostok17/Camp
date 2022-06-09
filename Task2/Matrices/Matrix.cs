using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    internal class Matrix
    {
        private int[,] _matrix;

        public int Rows { get; init; }
        public int Cols { get; init; }

        #region Ctors

        private Matrix() { }
        public Matrix(int n) : this(n, n) { }
        public Matrix(int rows, int columns) : this(rows, columns, null) { }
        public Matrix(int rows, int columns, int[,] matrix)
        {
            _matrix = (matrix == null) ? new int[rows, columns] : matrix;
            Rows = rows;
            Cols = columns;
        }

        #endregion

        #region Methods

        public void VerticalSnake()
        {
            int k = 0;

            bool isRevert = false;
            for (int j = 0; j < Cols; j++)
            {
                if (!isRevert)
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        _matrix[i, j] = ++k;
                    }
                    isRevert = true;
                }
                else
                {
                    for (int i = Rows - 1; i >= 0; i--)
                    {
                        _matrix[i, j] = ++k;
                    }
                    isRevert = false;
                }
            }
        }
        public void DiagonalSnake()
        {
            if (Rows != Cols)
                throw new Exception("Square matrix required (the same number of rows and columns).");

            int k = 0,
                maxValue = Rows * Cols;

            bool isRevert = false;
            for (int j = 0; j < Cols; j++)
            {
                if (!isRevert)
                {
                    for (int i = 0; i <= j; i++)
                    {
                        _matrix[j - i, i] = ++k;
                        _matrix[Rows - 1 - (j - i), Cols - 1 - i] = maxValue - (k - 1);
                    }
                    isRevert = true;
                }
                else
                {
                    for (int i = j; i >= 0; i--)
                    {
                        _matrix[j - i, i] = ++k;
                        _matrix[Rows - 1 - (j - i), Cols - 1 - i] = maxValue - (k - 1);
                    }
                    isRevert = false;
                }
            }
        }
        public void SpiralSnake()
        {
            int x1 = 0, y1 = 0, x2 = Rows - 1, y2 = Cols - 1;

            int k = 0,
                maxValue = Rows * Cols;

            int i = 0, j = 0;
            while (k < maxValue)
            {
                _matrix[i, j] = ++k;

                if (i < x2 && j == y1)
                    i++;
                else if (i == x2 && j < y2)
                    j++;
                else if (i > x1 && j == y2)
                    i--;
                else
                    j--;

                if (i == x1 && j == y1 + 1)
                {
                    x1++;
                    y1++;
                    x2--;
                    y2--;
                }
            }
        }
        public void FirstStageTask()
        {
            if (Rows != Cols || Rows % 2 == 0)
                throw new Exception("Matrix must be square and have unpaired number of rows.");

            for (int i = 0; i < Rows / 2; i++)
            {
                for (int j = Cols / 2 - 1 - i; j >= 0; j--)
                {
                    _matrix[i, j] = 1;
                    _matrix[i, Cols - 1 - j] = 2;
                    _matrix[Rows - 1 - i, j] = 3;
                    _matrix[Rows - 1 - i, Cols - 1 - j] = 4;
                }
            }
        }

        #endregion

        #region Object methods

        public override bool Equals(object? obj)
        {
            if (obj is Matrix m)
            {
                return ToString() == m.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append($"{_matrix[i, j],-3}");
                }
                sb.AppendLine();
            }
            return sb.Length == 0 ? "Empty matrix." : sb.ToString();
        }

        #endregion
    }
}
