using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.Exceptions;

namespace Task7
{
    internal static class FileParser
    {
        public static List<(Product, int)> Parse(string filename)
        {
            string path = Path.Combine(@"../../../assets/", filename);
            path = Path.GetFullPath(path);

            var products = new List<(Product, int)>();

            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException($"Could not find the file: '{path}'.");

                using (var sr = new StreamReader(path))
                {
                    string? header = sr.ReadLine();
                    if (header == null)
                        throw new InvalidHeaderException("Header is empty.", path);

                    if (header.Split(';').Length != 8)
                        throw new InvalidHeaderException("Invalid number of columns in file.", path);

                    int lineNumber = 0;
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var p = ParseProduct(line, ++lineNumber);
                        if (p.product is not null)
                        {
                            products.Add(p);
                        }
                    }
                }
            }
            catch (InvalidHeaderException ex)
            {
                Logger.Log(ex.Message + $" '{ex.FilePath}'");
            }
            return products;
        }
        public static (Product? product, int count) ParseProduct(string? line, int lineNum)
        {
            if (line == null)
                return (null, 0);

            string[] parts = line.Split(';');

            var info = new
            {
                Id = parts[0],
                Name = parts[1],
                Price = parts[2],
                Weight = parts[3],
                Grade = parts[4],
                Type = parts[5],
                ExpirationTerm = parts[6],
                Count = parts[7]
            };

            try
            {
                int id = int.Parse(info.Id);
                string name = CheckName(info.Name);
                decimal price = decimal.Parse(info.Price);
                double weight = double.Parse(info.Weight);
                int count = int.Parse(info.Count);

                if (string.IsNullOrEmpty(info.Type)
                    && string.IsNullOrEmpty(info.Grade)
                    && string.IsNullOrEmpty(info.ExpirationTerm))
                {
                    return (new Product(id, name, price, weight), count);
                }
                else if (string.IsNullOrEmpty(info.Grade)
                         && string.IsNullOrEmpty(info.Type)
                         && !string.IsNullOrEmpty(info.ExpirationTerm))
                {
                    int expirationTerm = int.Parse(info.ExpirationTerm);
                    return (new DairyProduct(id, name, price, weight, expirationTerm), count);
                }
                else if (!string.IsNullOrEmpty(info.Grade)
                         && !string.IsNullOrEmpty(info.Type)
                         && string.IsNullOrEmpty(info.ExpirationTerm))
                {
                    bool isGrade = Enum.TryParse(info.Grade, out MeatGradeEnum meatGrade);
                    bool isType = Enum.TryParse(info.Type, out MeatTypeEnum meatType);
                    if (!isGrade || !isType)
                        throw new FormatException("Invalid meat grade or type.");
                
                    return (new Meat(id, name, price, weight, meatGrade, meatType), count);
                }
                throw new FormatException();
            }
            catch (FormatException)
            {
                Logger.Log($"Invalid data in line {lineNum}.");
            }
            return (null, 0);
        }
        private static string CheckName(string name)
        {
            char firstCharacter = char.ToUpper(name[0]);
            return firstCharacter + name[1..];
        }
    }
}
