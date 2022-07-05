using Task8.ElectricityMetering;

var a = new ElectricityMetering();
a.FillData();

var b = new ElectricityMetering();
b.FillData();

var test = a - b;
Console.WriteLine(test);

Console.ReadKey();