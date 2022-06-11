using Task4;

Vector v = new Vector(new int[] { 8, 4, 3, 2, 9, 6, 3, 5 });

Console.WriteLine("Initial vector:\n" + v);

Vector.QuickSort(v, 0, v.Lenght - 1, PivotEnum.Random, OrderEnum.Descending);

Console.WriteLine("\nSorted vector:\n" + v);

Console.ReadKey();