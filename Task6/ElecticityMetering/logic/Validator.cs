using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.ElecticityMetering
{
    internal static class Validator
    {
        public static void CheckNumOfFlats(int numOfFlats)
        {
            if (numOfFlats < 0)
                throw new ArgumentOutOfRangeException("Number of flats must be" +
                    "a positive number of zero.", nameof(numOfFlats));
        }
        public static void CheckQuarter(int quarter)
        {
            if (quarter < 1 || quarter > 5)
                throw new ArgumentOutOfRangeException("Quarter must be greater than " +
                    "or equal to 1 and less than or equel to 4.", nameof(quarter));
        }
        public static void CheckInputOutputValues(double initial, double output)
        {
            if (initial < 0 || output < 0)
                throw new ArgumentOutOfRangeException("Initial and output values must be greater than" +
                    "of equal to zero.");

            if (initial > output)
                throw new ArgumentException("Output can't be less than initial. (initial > output)");

        }
        public static DateTime CheckDate(string date)
        {
            date = date.Trim();

            CultureInfo provider = new CultureInfo("en-US");
            string dateFormat = "dd.mm.yy";

            DateTime res;

            if (!DateTime.TryParse(date, provider, DateTimeStyles.None, out res))
                throw new ArgumentException("Invalid date format.");

            return res;
        }
    }
}
