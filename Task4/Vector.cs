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
        public int Lenght => _array.Length;

        public Vector(int[] arr)
        {
            _array = arr;
        }
        public Vector(int n)
        {
            _array = new int[n];
        }
        public Vector()
        {
            _array = Array.Empty<int>();
        }

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public override string ToString()
        {
            return string.Join(' ', _array);
        }

        public void RandomInitialization(int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < _array?.Length; i++)
            {
                _array[i] = random.Next(min, max);
            }
        }

        public void InitShuffle()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = i + 1;
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
            int lenght = _array.Length / 2;

            for (int i = 0; i < lenght; i++)
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

        #region Sort

        public static void QuickSort(Vector vec, int start, int end)
        {
            if (start < end)
            {
                int pivotIdx = Partition(vec, start, end);
                
                QuickSort(vec, start, pivotIdx - 1);
                QuickSort(vec, pivotIdx + 1, end);
            }
        }

        private static int Partition(Vector vec, int start, int end)
        {
            int pivot = vec[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (vec[j] < pivot)
                {
                    (vec[++i], vec[j]) = (vec[j], vec[i]);
                }
            }
            (vec[i + 1], vec[end]) = (vec[end], vec[i + 1]);

            return i + 1;
        }

        #endregion
    }
}
