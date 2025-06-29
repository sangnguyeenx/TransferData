using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan_Box.Common
{
   public class DataBox
    {
        public string KTMEDT { get; set; }
        public string KTPKNO { get; set; }
        public string KTHMCD { get; set; }
        public string KTSZNO { get; set; }
        public string KTLTNO { get; set; }
        public string KTLOTE { get; set; }
        public decimal OKQTY { get; set; } // KTWQTY as OKQTY
        public decimal NGQTY { get; set; } // KTNQTY as NGQTY
    }
}
