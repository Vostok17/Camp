using Matrices;

Matrix m = new Matrix(3);
m.RandomInit();
Console.WriteLine("Initial matris:\n{0}\n", m);

Console.WriteLine("Simple order:");
foreach (var item in m)
{
    Console.WriteLine(item);
}
Console.WriteLine();

Console.WriteLine("Horizontal snake order:");
foreach (var item in m.GetHorizontalSnakeOrder())
{
    Console.WriteLine(item);
}

Console.WriteLine("Diagonal snake order (up rigth):");
foreach (var item in m.GetDiagonalSnakeOrder(DiagonalShakeDirectionEnum.UpRight))
{
    Console.WriteLine(item);
}

Console.WriteLine("Diagonal snake order (left down):");
foreach (var item in m.GetDiagonalSnakeOrder(DiagonalShakeDirectionEnum.UpRight))
{
    Console.WriteLine(item);
}

Console.ReadKey();