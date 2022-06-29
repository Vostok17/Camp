using Task6;

ElectricityMetering em = new ElectricityMetering("quarter.txt");

em.Read();

//em.EditFlat(1);

em.PrintFlat(flatNumber: 1);

em.SaveToFile();

// The biggest cost.
Console.WriteLine("Flat with the biggest cost: {0}\n", em.FindFlatWithTheBiggestCost());

// Flats without electricity.
Console.WriteLine("Flats without electricity: ");
foreach (int flatNum in em.FindFlatsWithoutElecticity())
{
    Console.WriteLine(flatNum);
}

Console.ReadKey();