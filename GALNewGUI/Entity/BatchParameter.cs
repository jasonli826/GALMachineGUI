using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineNewGUI.Entity
{
    public class BatchParameter
    {
        public string ReservationNo { get; set; }
        public string BatchNo { get; set; }
        public string ModuleFromFactor { get; set; }

        public string ProductName { get; set;}

        public double ProductHeight { get; set; }

        public double ProductWidth { get; set; }

        public double ProductLength { get; set; }
    }
}
