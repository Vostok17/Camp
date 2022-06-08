using Task6;

ElectricityMetering em = new ElectricityMetering("quarter.csv");
em.Fill();

Console.WriteLine("Success!");
Console.ReadKey();