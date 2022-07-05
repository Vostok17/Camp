using Task8;

var products = new List<(Product, int)>()
{
    (new Product(1, "Coca-Cola", 12.50m, 1), 23),
    (new DairyProduct(2, "Milk", 135, 0.5, 12), 182),
    (new Meat(3, "Mutton", 180, 1, MeatGradeEnum.FirstGrade, MeatTypeEnum.Mutton), 12)
};

Storage st1 = new Storage(products);
Storage st2 = new Storage(products);

st1.AddProducts();

Console.WriteLine("Products that are in the first storage and not in the second:");
foreach (var item in st1.GetProducts().Except(st2.GetProducts()))
{
    Console.WriteLine($"{item.Count} - {item.Product}");
}
Console.WriteLine();

Console.WriteLine("Products that are common in both storages:");
foreach (var item in st1.GetProducts().Intersect(st2.GetProducts()))
{
    Console.WriteLine($"{item.Count} - {item.Product}");
}
Console.WriteLine();

Console.WriteLine("A common list of products that are in both storages, without repeating:");
foreach (var item in st1.GetProducts().Union(st2.GetProducts()))
{
    Console.WriteLine($"{item.Count} - {item.Product}");
}
Console.WriteLine();

Console.ReadKey();