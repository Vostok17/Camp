﻿using Task5;

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

try
{
    FileHandler initialVector = new FileHandler("vector.txt");

    Console.WriteLine("Initial vector (from file):\n{0}\n", initialVector.ReadVector());

    Vector.MergeSortWithFiles("vector.txt", 3, true);

    Console.WriteLine("Sorted vector (ExternalMergeSort):\n{0}\n", initialVector.ReadVector());
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

#endregion



Console.ReadKey();