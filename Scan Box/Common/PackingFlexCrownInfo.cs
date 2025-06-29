using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan_Box.Common
{
    class PackingFlexCrownInfo
    {
        public int PackingIDNo { get; set; }
        public string LotNo { get; set; }
        public string MPN { get; set; }
        public string CPN { get; set; }
        public string APN { get; set; }
        public string VC { get; set; }
        public int OKQty { get; set; }
        public int NGQty { get; set; }
        public string NGType { get; set; }
        public string Inspector { get; set; }
        public string QualifyNo { get; set; }
        public string DeviceId { get; set; }
        public string PO { get; set; }
        public string Desc { get; set; }
        public DateTime DateCode { get; set; }
        public string Config { get; set; }
        public string PackageNo { get; set; }
        public string BIN { get; set; }
        public string MSD { get; set; }
        public string Cavity { get; set; }
    }
}
