using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    internal class Matrix : IEnumerable<int>
    {
        private int[,] _matrix;

        public readonly int Rows;
        public readonly int Cols;

        public Matrix() : this(0, 0) { }
        public Matrix(int n) : this(n, n) { }
        public Matrix(int rows, int columns)
        {
            _matrix = new int[rows, columns];
            Rows = rows;
            Cols = columns;
        }

        #region Object methods

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sr.Append(string.Format($"{_matrix[i, j],-3}"));
                }
                sr.Append('\n');
            }
            sr.Append('\n');
            return sr.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Matrix other)
            {
                if (Rows != other.Rows || Cols != other.Cols)
                    return false;

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        if (_matrix[i, j] != other._matrix[i, j])
                            return false;
                    }
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        #endregion

        #region Methods

        public void RandomInit()
        {
            int[] values = new int[Rows * Cols];
            for (int i = 0; i < values.Length; i++)
                values[i] = i + 1;

            values = values.OrderBy(x => new Random().Next()).ToArray();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    _matrix[i, j] = values[i * Cols + j];
                }
            }
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

        #endregion

        #region IEnumerable

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    yield return _matrix[i, j];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<int> GetHorizontalSnakeOrder()
        {
            bool isRevert = false;
            for (int i = 0; i < Rows; i++)
            {
                if (!isRevert)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        yield return _matrix[i, j];
                    }
                    isRevert = true;
                }
                else
                {
                    for (int j = Cols - 1; j >= 0; j--)
                    {
                        yield return _matrix[i, j];
                    }
                    isRevert = false;
                }
            }
        }
        public IEnumerable<int> GetDiagonalSnakeOrder(DiagonalShakeDirectionEnum direction)
        {
            if (Rows != Cols)
                throw new Exception("Square matrix required (the same number of rows and columns).");

            bool isRevert = direction switch
            {
                DiagonalShakeDirectionEnum.UpRight => false,
                DiagonalShakeDirectionEnum.LeftDown => true,
                _ => throw new ArgumentException("Invalid option for direction.")
            };

            var mirroredSide = new List<int>();

            for (int j = 0; j < Cols; j++)
            {
                if (!isRevert)
                {
                    for (int i = 0; i <= j; i++)
                    {
                        yield return _matrix[j - i, i];
                        mirroredSide.Add(_matrix[Rows - 1 - (j - i), Cols - 1 - i]);
                    }
                    isRevert = true;
                }
                else
                {
                    for (int i = j; i >= 0; i--)
                    {
                        yield return _matrix[j - i, i];
                        mirroredSide.Add(_matrix[Rows - 1 - (j - i), Cols - 1 - i]);
                    }
                    isRevert = false;
                }
            }

            for (int i = mirroredSide.Count - 1 - Cols; i >= 0; i--)
            {
                yield return mirroredSide[i];
            }
        }

        #endregion
    }
}
