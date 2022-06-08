using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class UI
    {
        private int _separatorLength;
        public UI()
        {
            _separatorLength = 30;
        }

        public (int numOfFlats, int quarter) FillFisrtLine()
        {
            Console.WriteLine(new string('=', _separatorLength));

            int numOfFlats, quarter;
            try
            {
                Console.Write("Enter the number of flats: ");
                if (!int.TryParse(Console.ReadLine(), out numOfFlats))
                    throw new ArgumentException("Invalid input for number of flats.", nameof(numOfFlats));
                Validator.CheckNumOfFlats(numOfFlats);

                Console.Write("Enter the quarter: ");
                if (!int.TryParse(Console.ReadLine(), out quarter))
                    throw new ArgumentException("Invalid input for quarter.", nameof(quarter));
                Validator.CheckQuarter(quarter);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return FillFisrtLine();
            }
            Feedback("Done!");
            Console.WriteLine(new string('=', _separatorLength));
            return (numOfFlats, quarter);
        }

        public void FillFlatData(int flatNum)
        {
            Console.WriteLine(new string('-', _separatorLength));

            string ownerSurname;
            double initialValue, outputValue;
            DateTime initialDate, outputDate;

            try
            {
                Console.WriteLine("Flat number: {0}", flatNum);

                Console.Write("Owner's surname: ");
                ownerSurname = Console.ReadLine();
                            
                if (string.IsNullOrEmpty(ownerSurname))
                    throw new ArgumentException("Surname can't be empty.", nameof(ownerSurname));

                Console.Write("Initial date (expected format dd.mm.yyyy): ");
                initialDate = Validator.CheckDate(Console.ReadLine());

                Console.Write("Initial value: ");
                if (!double.TryParse(Console.ReadLine(), out initialValue))
                    throw new ArgumentException("Invalid input for initial value.", nameof(initialValue));

                Console.Write("Output date (expected format dd.mm.yyyy): ");
                outputDate = Validator.CheckDate(Console.ReadLine());

                Console.Write("Output value: ");
                if (!double.TryParse(Console.ReadLine(), out outputValue))
                    throw new ArgumentException("Invalid input for output value.", nameof(outputValue));

                Validator.CheckInputOutputValues(initialValue, outputValue);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                FillFlatData(flatNum);
            }
            Feedback("Done!");
        }

        private void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void Feedback(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
