using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Meat : Product
    {
        public MeatGradeEnum? MeatGrade { get; init; }
        public MeatTypeEnum? MeatType { get; init; }

        public Meat() { }
        public Meat(int id, string name, decimal price, double weight,
            MeatGradeEnum meatGrade, MeatTypeEnum meatType)
            : base(id, name, price, weight)
        {
            MeatType = meatType;
            MeatGrade = meatGrade;
        }

        public override string ToString()
        {
            return $"{base.ToString().TrimEnd('.')}, Grade: {MeatGrade}, Type: {MeatType}.";
        }

        public override void ChangePrice(double percentage)
        {
            percentage += MeatGrade switch
            {
                MeatGradeEnum.FirstGrade => 25,
                MeatGradeEnum.SecondGrade => 10,
                _ => 0,
            };
            base.ChangePrice(percentage);
        }
    }
}
