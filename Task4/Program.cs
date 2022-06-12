using Task4;

Vector v = new Vector(new int[] { 12, 3, 5, 7, 4, 19, 24, 11, 8 });

Console.WriteLine("Initial vector:\n" + v);

Vector.QuickSort(v, 0, v.Lenght - 1, true, PivotEnum.MedianOfThree);

Console.WriteLine("\nSorted vector:\n" + v);

Console.Write("\nMedian: {0}\n", Vector.FindMedian(v));

Console.ReadKey();