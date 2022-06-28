using Task6;

ElectricityMetering em = new ElectricityMetering("quarter.txt");
//em.FillData();

//em.SaveToJson();
//em.SaveToFile();

em.Read();

em.SaveToFile();

var antype = new { namedddddddddddddddddddd = "hellodfgdfg", time = DateTime.Now };
//var test2 = antype with { name = "done" };

var list = new List<object>();

list.Add(antype);
//list.Add(test2);

var table = new Table(list.ToArray());

Console.WriteLine(table);

Console.WriteLine("Success!");
Console.ReadKey();