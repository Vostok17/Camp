using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Vector
    {
        private int[] _array;
        private static int high;

        public int Lenght => _array.Length;

        public Vector() { }
        public Vector(int n)
        {
            _array = new int[n];
        }
        public Vector(int[] arr)
        {
            _array = arr;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= _array.Length)
                    throw new IndexOutOfRangeException(
                        "Index must be greater than or equal to zero and less than lenght.");
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _array.Length)
                    throw new IndexOutOfRangeException(
                        "Index must be greater than or equal to zero and less than lenght.");
                _array[index] = value;
            }
        }

        #region Object methods

        public override bool Equals(object? obj)
        {
            if (obj is Vector other)
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
            return string.Join(' ', _array);
        }

        #endregion

        #region Methods

        public void RandomInitialization(int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(min, max);
            }
        }
        public void InitShuffle()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = i;
            }
            Random random = new Random();
            _array = _array.OrderBy(x => random.Next()).ToArray();
        }
        public Pair[] CalculateFrequency()
        {
            var res = _array
                .GroupBy(x => x)
                .Select(x => new Pair(x.Key, x.Count()))
                .ToArray();

            return res;
        }
        public bool IsPalindrome()
        {
            bool isPalindrom = true;
            for (int i = 0; i < _array?.Length / 2; i++)
            {
                if (_array[i] != _array[_array.Length - 1 - i])
                {
                    isPalindrom = false;
                    break;
                }
            }
            return isPalindrom;
        }
        public void Reverse()
        {
            int lenght = _array.Length;

            for (int i = 0; i < lenght / 2; i++)
            {
                (_array[i], _array[lenght - 1 - i]) = (_array[lenght - 1 - i], _array[i]);
            }
        }
        public string FindLongestSequence()
        {
            int? resNum = null;
            int maxCount = 1;
            int count = 1;

            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] == _array[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        resNum = _array[i];
                        maxCount = count;
                    }
                    count = 1;
                }
            }

            if (resNum != null)
                return $"Number {resNum} occurs {maxCount} times in a row.";
            else
                return "Every number occurs only once.";
        }

        #endregion

        #region Sort

        public static void QuickSort(
            Vector v, int start, int end, PivotEnum pivotEnum, OrderEnum orderEnum)
        {
            if (start >= end)
                return;

            int pivot = pivotEnum switch
            {
                PivotEnum.LastElement => v[end],
                PivotEnum.FirstElement => v[start],
                PivotEnum.MiddleElement => v[(start + end) / 2],
                PivotEnum.Random => v[new Random().Next(start, end + 1)],
                _ => throw new NotImplementedException("Invalid option in pivot enum.")
            };

            int order = orderEnum switch
            {
                OrderEnum.Descending => -1,
                _ => 1
            };

            int l = start, r = end;

            do
            {
                while (order * v[l] < order * pivot) l++;
                while (order * v[r] > order * pivot) r--;

                if (l <= r)
                {
                    (v[l], v[r]) = (v[r], v[l]);
                    l++;
                    r--;
                }
            } while (l <= r);

            QuickSort(v, l, end, pivotEnum, orderEnum);
            QuickSort(v, start, r, pivotEnum, orderEnum);
        }

        #endregion
    }
}