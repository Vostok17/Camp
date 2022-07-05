using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class UI
    {
        public List<(Product Product, int Count)> PopulateProducts()
        {
            var products = new List<(Product, int)>();

            bool isExit = false;
            do
            {
                string choice = ChooseOption("Product", "Meat", "DairyProduct");

                Product? p = choice switch
                {
                    "Product" => PopulateProduct(),
                    "Meat" => PopulateMeat(),
                    "DairyProduct" => PopulateDairyProduct(),
                    _ => null,
                };

                bool isCountValid = false;
                int count = 0;
                do
                {
                    try
                    {
                        Console.Write("Count: ");
                        if (!int.TryParse(Console.ReadLine(), out count))
                            throw new ArgumentException("Invalid count.");
                        if (count < 0)
                            throw new ArgumentException("Count must be greater than zero.");
                        isCountValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + '\n');
                    }
                } while (!isCountValid);

                if (p is not null)
                    products.Add((p, count));

                Console.Write("Press Q to exit or any key to continue: ");
                string exit = Console.ReadLine();

                if (exit.Equals("q", StringComparison.OrdinalIgnoreCase))
                    isExit = true;
                Console.WriteLine();

            } while (!isExit);

            return products;
        }
        private Product PopulateDairyProduct()
        {
            Product p = PopulateProduct();
            int term = 0;

            bool isExit = false;
            do
            {
                try
                {
                    Console.Write("Term: ");
                    if (!int.TryParse(Console.ReadLine(), out term))
                        throw new ArgumentException("Invalid value for term.");
                    isExit = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (!isExit);

            return new DairyProduct((int)p.Id, p.Name, p.Price, p.Weight, term);
        }
        private Product PopulateMeat()
        {
            Product p = PopulateProduct();

            string grade = ChooseOption("No grade", "First grade", "Second grade");
            MeatGradeEnum meatGrade = grade switch
            {
                "First grade" => MeatGradeEnum.FirstGrade,
                "Second grade" => MeatGradeEnum.SecondGrade
            };

            string type = ChooseOption("Mutton", "Veal", "Pork", "Chicken");
            MeatTypeEnum meatType = type switch
            {
                "Mutton" => MeatTypeEnum.Mutton,
                "Veal" => MeatTypeEnum.Veal,
                "Pork" => MeatTypeEnum.Pork,
                "Chicken" => MeatTypeEnum.Chicken
            };

            return new Meat((int)p.Id, p.Name, p.Price, p.Weight, meatGrade, meatType);
        }       
        private Product PopulateProduct()
        {
            Product product;
            try
            {
                Console.Write("Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new ArgumentException("Invalid id.");

                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Name can't be empty.", nameof(name));

                Console.Write("Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    throw new ArgumentException("Invalid price.");

                Console.Write("Weight: ");
                if (!double.TryParse(Console.ReadLine(), out double weight))
                    throw new ArgumentException("Invalid weight.");

                return new Product(id, name, price, weight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + '\n');
                return PopulateProduct();
            }
        }
        private string ChooseOption(params string[] options)
        {
            try
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {options[i]}");
                }
                Console.Write("Choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                    throw new ArgumentOutOfRangeException("Choice",
                        $"Select option in range 1..{options.Length}.");

                return options[--choice];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + '\n');
                return ChooseOption(options);
            }
        }
        public string AskForFilename()
        {
            Console.Write("Please, enter the name of the file: ");
            return Console.ReadLine();
        }
    }
}
