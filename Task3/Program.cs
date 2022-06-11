using Task3;

#region Random Initialization and Reverse

Vector v = new Vector(10);
v.RandomInitialization(1, v.Lenght);
Console.WriteLine("Initialized vector:\n" + v + '\n');

v.Reverse();
Console.WriteLine("Reversed vector:\n" + v + '\n');

#endregion

#region IsPalindrome and FindLongestSequence

Vector palindrome = new Vector(new int[] { 1, 2, 3, 2, 1 });
Console.WriteLine(palindrome);
Console.WriteLine("Is palindrome? {0}", palindrome.IsPalindrome());

Console.WriteLine("\nFind longest sequence:");
Vector testVector = new Vector(new int[] { 9, 2, 4, 4, 5, 4, 4, 4, 5, 4, 3, 3, 2 });
Console.WriteLine(testVector);
Console.WriteLine(testVector.FindLongestSequence());

#endregion

#region InitShuffle and CalculateFrequency

Vector vecToShuffle = new Vector(20);
vecToShuffle.InitShuffle();
Console.WriteLine("\nShuffled array:\n" + vecToShuffle);

Console.WriteLine($"\nFrequency for testVector:\n" + testVector);
Pair[] freq = testVector.CalculateFrequency();
foreach (Pair pair in freq)
    Console.WriteLine(pair);

#endregion

#region Diagonal snake with direction

Console.WriteLine("\nDiagonal snake with direction:");
Matrix matrix = new Matrix(4);

Console.WriteLine("\nUp right:\n");
matrix.DiagonalSnake(DiagonalShakeDirectionEnum.UpRight);
Console.WriteLine(matrix);

Console.WriteLine("Left down:\n");
matrix.DiagonalSnake(DiagonalShakeDirectionEnum.LeftDown);
Console.WriteLine(matrix);

#endregion

Console.ReadKey();