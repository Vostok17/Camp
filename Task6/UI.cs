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
        public UI(int separatorLength)
        {
            _separatorLength = separatorLength;
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
        public Flat FillFlatData(int flatNum)
        {
            Console.WriteLine(new string('-', _separatorLength));

            string ownerSurname;
            double startValue, endValue;
            DateTime startDate, endDate;

            try
            {
                Console.WriteLine("Flat number: {0}", flatNum);

                Console.Write("Owner's surname: ");
                ownerSurname = Console.ReadLine();
                            
                if (string.IsNullOrEmpty(ownerSurname))
                    throw new ArgumentException("Surname can't be empty.", nameof(ownerSurname));

                Console.Write("Initial date (expected format dd.mm.yyyy): ");
                startDate = Validator.CheckDate(Console.ReadLine());

                Console.Write("Initial value: ");
                if (!double.TryParse(Console.ReadLine(), out startValue))
                    throw new ArgumentException("Invalid input for initial value.", nameof(startValue));

                Console.Write("Output date (expected format dd.mm.yyyy): ");
                endDate = Validator.CheckDate(Console.ReadLine());

                Console.Write("Output value: ");
                if (!double.TryParse(Console.ReadLine(), out endValue))
                    throw new ArgumentException("Invalid input for output value.", nameof(endValue));

                Validator.CheckInputOutputValues(startValue, endValue);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return FillFlatData(flatNum);
            }
            Feedback("Done!");

            return new Flat
            {
                Number = flatNum,
                Owner = ownerSurname,
                StartDate = startDate,
                StartValue = startValue,
                EndDate = endDate,
                EndValue = endValue
            };
        }
        private void Error(string msg)
        {
            Msg(msg, ConsoleColor.Red);
        }
        private void Feedback(string msg)
        {
            Msg(msg, ConsoleColor.Green);
        }
        private void Msg(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
