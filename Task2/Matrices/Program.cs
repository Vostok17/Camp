using Matrices;

Console.WriteLine("Vertical snake:");
Matrix m1 = new Matrix(3, 4);

m1.VerticalSnake();
Console.WriteLine(m1);

Console.WriteLine("Diagonal snake:");
Matrix m2 = new Matrix(4);

m2.DiagonalSnake();
Console.WriteLine(m2);

Console.WriteLine("Spiral snake:");
Matrix m3 = new Matrix(3, 4);

m3.SpiralSnake();
Console.WriteLine(m3);

Console.WriteLine("Task from first stage:");
Matrix m4 = new Matrix(9);

m4.FirstStageTask();
Console.WriteLine(m4);

Console.ReadKey();