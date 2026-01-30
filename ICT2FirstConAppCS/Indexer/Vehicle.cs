using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2FirstConAppCS.Indexer
{
    internal class Vehicle
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string  Make { get; set; }
        public int Rate { get; set; }
        public override string ToString()
        {
            return ID + " - " + Model + " - " + Make + " - " + Rate;
        }
    }
}
