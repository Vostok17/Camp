using IPAddresses;

FileHandler file = new FileHandler("data.csv");

var data = file.Read();

Console.WriteLine("Raw data:");
foreach (var item in data)
{
    Console.WriteLine($"{item.ip} - {item.time.ToLongTimeString()} - {item.day}");
}
Console.WriteLine();

Statistics statistics = new Statistics(data);

Console.WriteLine("Count of visits:");
foreach (var item in statistics.GetCountOfVisits())
{
    Console.WriteLine($"{item.ip} - {item.count}");
}
Console.WriteLine();

Console.WriteLine("Most popular days:");
foreach (var item in statistics.GetTheMostPopularDays())
{
    Console.WriteLine($"{item.ip} - {item.day}");
}
Console.WriteLine();

Console.WriteLine("Most active hours for IPs:");
foreach (var item in statistics.GetTheMostActiveHours())
{
    Console.WriteLine($"{item.ip}: {item.time} - {item.time.AddHours(1)}");
}
Console.WriteLine();

Console.WriteLine("Most active hours for days:");
foreach (var item in statistics.GetTheMostActiveHoursForSite())
{
    Console.WriteLine($"{item.day}: {item.time} - {item.time.AddHours(1)}");
}

Console.ReadKey();