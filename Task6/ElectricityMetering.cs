using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class ElectricityMetering
    {
        private readonly string _filename;
        private readonly UI? _ui = new UI();

        public int Quarter { get; set; }
        public int FlatsCount { get; set; }
        public Flat[] Flats { get; set; }

        public ElectricityMetering() { }
        public ElectricityMetering(string filename)
        {
            _filename = filename;
        }

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

        public void FillData()
        {
            (FlatsCount, Quarter) = _ui.FillFisrtLine();
            Flats = new Flat[FlatsCount];

            for (int i = 0; i < FlatsCount; i++)
            {
                Flats[i] = _ui.FillFlatData(i + 1);
            }
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
    }
}
