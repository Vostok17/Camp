using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Matrix
    {
        private int[,] _matrix;

        public readonly int Rows;
        public readonly int Cols;

        public Matrix()
        {
            _matrix = new int[0, 0];
        }
        public Matrix(int n) : this(n, n) { }
        public Matrix(int rows, int columns)
        {
            _matrix = new int[rows, columns];
            Rows = rows;
            Cols = columns;
        }

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
        public void DiagonalSnake(DiagonalShakeDirectionEnum direction)
        {
            if (Rows != Cols)
                throw new Exception("Square matrix required (the same number of rows and columns).");

            int k = 0,
                maxValue = Rows * Cols;
            bool isRevert = direction switch
            {
                DiagonalShakeDirectionEnum.UpRight => false,
                DiagonalShakeDirectionEnum.LeftDown => true,
                _ => throw new ArgumentException("Invalid option direction.")
            };

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
        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sr.Append(string.Format($"{_matrix[i, j], -3}"));
                }
                sr.Append('\n');
            }
            sr.Append('\n');
            return sr.ToString();
        }
    }
}
