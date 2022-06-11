using Task4;

Vector v = new Vector(new int[] { 12, 3, 5, 7, 4, 19, 26 });

Console.WriteLine("Initial vector:\n" + v);

Vector.QuickSort(v, 0, v.Lenght - 1, PivotEnum.Median, OrderEnum.Descending);

Console.WriteLine("\nSorted vector:\n" + v);

Console.ReadKey();