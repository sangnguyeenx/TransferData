using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan_Box.Common
{
    public class BoxHistory
    {
      
        public string BoxNo { get; set; }
        public string MPN { get; set; }
        public string LotNo { get; set; }
        public string PackageNo { get; set; }
        public Decimal OKQuantity { get; set; }
        public Decimal NGQuantity { get; set; }
        public string NGType { get; set; }
        public string StaffNo { get; set; }
        public DateTime EnterTime { get; set; }
    }
}
