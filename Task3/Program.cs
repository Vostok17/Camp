using Task3;

Vector vec = new Vector(10);
vec.RandomInitialization(1, vec.Lenght);
Console.WriteLine(vec.ToString());

vec.Reverse();
Console.WriteLine(vec.ToString());

Vector palindrome = new Vector(new int[] { 1, 2, 3, 2, 1 });
Console.WriteLine($"\n{palindrome}");
Console.WriteLine("Is palindrome? {0}", palindrome.IsPalindrome());

Console.WriteLine("\nFind longest sequence:");
Vector testVector = new Vector(new int[] { 9, 2, 4, 4, 5, 4, 4, 4, 5, 4, 3, 3, 2 });
Console.WriteLine(testVector.ToString());
Console.WriteLine(testVector.FindLongestSequence());

Vector vecToInit = new Vector(20);
vecToInit.InitShuffle();
Console.WriteLine($"\nShuffled array:\n{vecToInit}");

Console.WriteLine($"\nFrequency for testVector:\n{testVector}\n");
Pair[] freq = testVector.CalculateFrequency();
foreach (Pair pair in freq)
{
    Console.WriteLine(pair.ToString());
}

Console.WriteLine("\nDiagonal snake with direction:");
Matrix matrix = new Matrix(4);

Console.WriteLine("\nUp right:\n");
matrix.DiagonalSnake(DiagonalShakeDirectionEnum.UpRight);
Console.WriteLine(matrix);

Console.WriteLine("Left down:\n");
matrix.DiagonalSnake(DiagonalShakeDirectionEnum.LeftDown);
Console.WriteLine(matrix);

Console.ReadKey();