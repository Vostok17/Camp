using Task5;

Vector v = new Vector(new int[] { 9, 3, 5, 3, 5, 33, 4, 100 });

Console.WriteLine("Initial vector:\n{0}", v);

Vector.HeapSort(v, OrderEnum.Descending);

Console.WriteLine("\nSorted vector:\n{0}", v);

Console.ReadKey();