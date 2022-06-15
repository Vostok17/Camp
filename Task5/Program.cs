using Task5;

#region HeapSort

Vector v = new Vector(new int[] { 9, 3, 5, 3, 5, 33, 4, 100 });

Console.WriteLine("Initial vector:\n{0}", v);

Vector.HeapSort(v, true);

Console.WriteLine("\nSorted vector (HeapSort):\n{0}\n", v);

#endregion

#region MergeSort

v = new Vector(new int[] { 9, 3, 5, 3, 5, 33, 4, 100 });

Console.WriteLine("Initial vector:\n{0}", v);

Vector.MergeSort(v, 0, v.Lenght - 1, true);

Console.WriteLine("\nSorted vector (MergeSort):\n{0}\n", v);

#endregion

#region MergeSortWithFiles

FileHandler initialVector = new FileHandler("vector.txt");

Console.WriteLine("Initial vector (from file):\n{0}\n", initialVector.ReadVector());

Vector.MergeSortWithFiles("vector.txt", 3);

Console.WriteLine("Sorted vector (ExternalMergeSort):\n{0}\n", initialVector.ReadVector());

#endregion

Console.ReadKey();