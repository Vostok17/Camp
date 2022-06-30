using Task7;

#region Create Product instances

Product apple = new Product
{
    Id = 0,
    Name = "Red apple",
    Price = 12.5m,
    Weight = 3
};

Product banana = new Product(1, "Yellow banana", price: 24m, weight: 1);

Product orange = new Product(1, "Orange orange :D", price: 34.5m, weight: 0.5)
{
    Id = 2
};

List<Product> products = new List<Product>
{
    apple,
    banana
};

#endregion

#region Buy (Add, Remove)

Buy basket = new Buy(apple, banana);
basket.Add(products);
basket.Add(orange);

Console.WriteLine(basket);

basket.Remove(0, 1);
basket.Remove(2, 2);

Console.WriteLine(basket);

#endregion

#region Check

Check check = new Check(basket);
Console.WriteLine(check);

#endregion

#region Storage methods

var prods = new List<(Product, int)>
{
    (new Product(0, "Some Product", 12m, 0.750), 1),
    (new Meat(1, "Some Veal", 200m, 1, MeatGradeEnum.FirstGrade, MeatTypeEnum.Veal), 5),
    (new DairyProduct(2, "Milk", 36m, 0.900, 12), 2)
};

Storage storage = new Storage(prods);
Console.WriteLine(storage);

// 'Some Veal' price is 200, +10% + 25% (because of FirstGrade) -> 270
// 'Milk' price is 36, +10% +15% (because term < 20) -> 45
storage.ChangePrices(10);
Console.WriteLine(storage);

var meatProds = storage.FindAllMeatProducts();

Console.WriteLine("Meat products is storage: ");
foreach (var item in meatProds)
{
    Console.WriteLine($"{item.Count} - {item.Meat}");
}
Console.WriteLine();

#endregion

#region User's input

storage.AddProducts();

Console.WriteLine(storage);

#endregion

Console.ReadKey();