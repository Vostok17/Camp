using Task1;

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

#region Busket (Add, Remove)

Buy basket = new Buy(apple, banana);
basket.Add(products);
basket.Add(orange);

Console.WriteLine(basket);

basket.Remove(0, 1);
basket.Remove(2, 2);

Console.WriteLine(basket);

#endregion



//Check.DisplayInfo(basket);

Console.ReadKey();