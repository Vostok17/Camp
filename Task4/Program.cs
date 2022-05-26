using Task4;

Vector v = new Vector(new int[] { 4, 7, 9, 6, 5, 4, 3, 2, 1, 4, 5, 6, 7, 8, 8434, 1, 3, 5, 45, });

Console.WriteLine("Initial vector:\n" + v);

Vector.QuickSort(v, 0, v.Lenght - 1);

Console.WriteLine("\nSorted vector:\n" + v);

Console.ReadKey();