using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Vector
    {
        private int[] _array;

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

        #region QuickSort and QuickSelect

        public static void QuickSort(Vector v, int start, int end, 
            bool descending = false, PivotEnum pivotEnum = PivotEnum.Random)
        {
            if (start >= end)
                return;

            int pivot = pivotEnum switch
            {
                PivotEnum.LastElement => v[end],
                PivotEnum.FirstElement => v[start],
                PivotEnum.MiddleElement => v[(start + end) / 2],
                PivotEnum.Random => v[new Random().Next(start, end + 1)],
                PivotEnum.MedianOfThree => MedianOfThree(v, start, (end - start) / 2, end),
                _ => throw new NotImplementedException("Invalid option in pivot enum.")
            };

            int order = descending ? -1 : 1;

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

            QuickSort(v, l, end, descending, pivotEnum);
            QuickSort(v, start, r, descending, pivotEnum);
        }

        private static int Partition(Vector v, int start, int end)
        {
            int pivot = v[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (v[j] < pivot)
                {
                    i++;
                    (v[j], v[i]) = (v[i], v[j]);
                }
            }
            (v[i + 1], v[end]) = (v[end], v[i + 1]);
            return i + 1;
        }
        private static int QuickSelect(Vector v, int start, int end, int k)
        {
            int idx = Partition(v, start, end);

            if (idx == k)
                return v[idx];
            else if (idx < k)
                return QuickSelect(v, idx + 1, end, k);
            else
                return QuickSelect(v, start, idx - 1, k);
        }
        public static int FindMedian(Vector v)
        {
            int length = v.Lenght;

            if (length % 2 == 1)
            {
                return QuickSelect(v, 0, length - 1, length / 2);
            }
            else
            {
                int a = QuickSelect(v, 0, length - 1, length / 2);
                int b = QuickSelect(v, 0, length - 1, length / 2 - 1);
                return (a + b) / 2;
            }
        }
        private static int MedianOfThree(Vector v, int first, int middle, int last)
        {
            int[] arr = new int[] { v[first], v[middle], v[last] };
            Array.Sort(arr);

            return arr[1];
        }

        #endregion

        #region MergeSort

        public static void MergeSort(Vector vec, int l, int r, bool descending = false)
        {
            if (l < r)
            {
                int middlePoint = l + (r - l) / 2;

                MergeSort(vec, l, middlePoint, descending);
                MergeSort(vec, middlePoint + 1, r, descending);

                Merge(vec, l, middlePoint, r, descending);
            }
        }
        private static void Merge(Vector vec, int l, int middlePoint, int r, bool descending)
        {
            int sizeL = middlePoint - l + 1,
                sizeR = r - middlePoint;

            int[] tempL = new int[sizeL],
                tempR = new int[sizeR];


            int i, j;
            for (i = 0; i < sizeL; i++)
                tempL[i] = vec[l + i];

            for (j = 0; j < sizeR; j++)
                tempR[j] = vec[middlePoint + 1 + j];

            i = 0;
            j = 0;
            int idx = l;

            int order = descending ? -1 : 1;

            while (i < sizeL && j < sizeR)
            {
                if (order * tempL[i] <= order * tempR[j])
                {
                    vec[idx] = tempL[i];
                    i++;
                }
                else
                {
                    vec[idx] = tempR[j];
                    j++;
                }
                idx++;
            }

            while (i < sizeL)
            {
                vec[idx] = tempL[i];
                i++;
                idx++;
            }

            while (j < sizeR)
            {
                vec[idx] = tempR[j];
                j++;
                idx++;
            }
        }
        public static void MergeSortWithFiles(string filename, int numberOfChunks, bool descending = false)
        {
            var mainFile = new FileHandler(filename);

            List<string> files = mainFile.Split(numberOfChunks);

            foreach (string file in files)
            {
                var hf = new FileHandler(file);
                Vector v = hf.ReadVector();
                MergeSort(v, 0, v.Lenght - 1, descending);
                hf.WriteVector(v);
            }

            mainFile.Merge(files);
        }

        #endregion

        #region HeapSort

        public static void HeapSort(Vector v, bool descending = false)
        {
            int n = v.Lenght;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(v, n, i, descending);

            for (int i = n - 1; i > 0; i--)
            {
                // Move root to end.
                (v[0], v[i]) = (v[i], v[0]);

                Heapify(v, i, 0, descending);
            }
        }
        private static void Heapify(Vector v, int n, int root, bool descending)
        {
            int largest = root;
            int leftNode = 2 * root + 1;
            int rightNode = 2 * root + 2;

            int order = descending ? -1 : 1;

            if (leftNode < n && order * v[leftNode] > order * v[largest])
                largest = leftNode;

            if (rightNode < n && order * v[rightNode] > order * v[largest])
                largest = rightNode;

            if (largest != root)
            {
                (v[largest], v[root]) = (v[root], v[largest]);

                // Recursively update subtree.
                Heapify(v, n, largest, descending);
            }
        }

        #endregion

        #endregion
    }
}