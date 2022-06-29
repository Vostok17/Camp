using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.ElecticityMetering
{
    internal class ElectricityMetering
    {
        #region Fields

        private readonly string _filename;
        private readonly UI? _ui = new UI();

        #endregion

        #region Props

        public int Quarter { get; set; }
        public int FlatsCount { get; set; }
        public Flat[] Flats { get; set; }

        #endregion

        #region Ctors

        public ElectricityMetering() { }
        public ElectricityMetering(string filename)
        {
            _filename = filename;
        }

        #endregion

        #region Object methods

        public override string ToString()
        {
            var res = new StringBuilder();
            res.AppendFormat("Quarter: {0}, Number of Flats: {1}.", Quarter, FlatsCount);
            res.AppendLine();

            foreach (Flat flat in Flats)
            {
                res.AppendLine(flat.ToString());
            }
            return res.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is ElectricityMetering other)
            {
                return ToString() == other.ToString();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        #endregion

        #region Methods

        public void FillData()
        {
            (FlatsCount, Quarter) = _ui.FillFisrtLine();
            Flats = new Flat[FlatsCount];

            for (int i = 0; i < FlatsCount; i++)
            {
                Flats[i] = _ui.FillFlatData(i + 1);
            }
        }
        public void EditFlat(int flatNumber)
        {
            Flat flat = _ui.FillFlatData(flatNumber);

            // Add or replace flat.
            int idx = Array.IndexOf(Flats, flat);
            if (idx >= 0)
            {
                Flats[idx] = flat;
            }
        }
        public void PrintFlat(int flatNumber)
        {
            var flat = from f in Flats
                       where f.Number == flatNumber
                       select f;

            // Flat number is unique.
            Flat resFlat = flat.First();
            _ui.PrintFlat(resFlat);
        }
        public void SaveToJson()
        {
            var fh = new FileHandler("data.json");
            fh.SaveToJson(this);
        }
        public void SaveToFile()
        {
            var fh = new FileHandler(_filename);
            fh.SaveToFile(this);
        }
        public void Read()
        {
            var fh = new FileHandler("data.json");

            ElectricityMetering? em = fh.Read();
            if (em != null)
            {
                Quarter = em.Quarter;
                FlatsCount = em.FlatsCount;
                Flats = em.Flats;
            }
        }
        public int FindFlatWithTheBiggestCost()
        {
            return Flats.OrderByDescending(x => x.EndValue - x.StartValue).First().Number;
        }
        public int[] FindFlatsWithoutElecticity()
        {
            var flatsNum = from f in Flats
                        where f.EndValue - f.StartValue == 0
                        select f.Number;

            return flatsNum.ToArray();
        }

        #endregion
    }
}
