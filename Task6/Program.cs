using Task6;

ElectricityMetering em = new ElectricityMetering("quarter.txt");

em.Read();

//em.EditFlat(1);

em.PrintFlat(1);

em.SaveToFile();

Console.ReadKey();