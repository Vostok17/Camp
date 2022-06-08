using Task1;

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

Product test = new Product();
Console.WriteLine(test);

var (id, name, price, weight) = test;

Console.WriteLine(id+name+price+weight);


//Buy basket = new Buy(apple, banana);
//basket.Add(apple, banana, milk);

//Check.DisplayInfo(basket);

Console.ReadKey();