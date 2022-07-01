using Task7;

Storage storage = new Storage();
storage.ReadFromFile();

Console.WriteLine(storage);

try
{
    string[] logs = Logger.ContentAfterDate("01.07.2022");
    foreach (var item in logs)
    {
        Console.WriteLine(item);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();