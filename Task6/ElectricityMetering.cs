using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class ElectricityMetering
    {
        private FileHandler _fh;
        private UI _ui;

        public ElectricityMetering(string filename)
        {
            _fh = new FileHandler(filename);
            _ui = new UI();
        }

        public void Fill()
        {
            var (numOfFlats, quarter) = _ui.FillFisrtLine();

            for (int i = 0; i < numOfFlats; i++)
            {
                _ui.FillFlatData(i + 1);
            }
        }
    }
}
