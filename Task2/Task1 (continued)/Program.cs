using System.Runtime.CompilerServices;
using Task2;

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

Meat mutton = new Meat("Mutton", 10m, 2.25, MeatGradeEnum.FirstGrade, MeatTypeEnum.Mutton);
Meat veal = new Meat()
{
    MeatType = MeatTypeEnum.Veal
};

Console.WriteLine("\nBefore the change: {0}", mutton.Price);
mutton.ChangePrice(10);
Console.WriteLine("After the change: {0}", mutton.Price);

DairyProduct sourcream = new DairyProduct("Sourcream", 10m, 0.50, 33);

Console.WriteLine("\nBefore the change: {0}", sourcream.Price);
sourcream.ChangePrice(10);
Console.WriteLine("After the change: {0}", sourcream.Price);

Storage storage = new Storage();
storage.AddProducts();

Console.WriteLine(storage.ToString());
storage.PrintAll();

List<Product> exampleList = new List<Product>()
{
    new Product(),
    new Meat(),
    new DairyProduct()
};
Storage anotherStorage = new Storage(exampleList);

Console.WriteLine(anotherStorage.ToString());
anotherStorage.PrintAll();

Console.WriteLine("Types in storage:");
for (int i = 0; i < storage.Capasity; i++)
{
    Console.WriteLine($"{storage[i].Name} - {storage[i].GetType().Name}");
}
Console.WriteLine();

List<Meat> meatProducts = storage.FindAllMeatProducts();
Console.WriteLine("Meat products:");
foreach (Meat meat in meatProducts)
{
    Console.WriteLine(meat.ToString());
}
Console.WriteLine();

storage.ChangePrices(10);
storage.PrintAll();

Console.ReadKey();