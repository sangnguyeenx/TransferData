using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan_Box.Common
{
    class PackingOrderInfo
    {
        public int PackingOrderNo { get; set; }         
        public string LotNo { get; set; }              
        public string MPN { get; set; }                  
        public string CPN1 { get; set; }                
        public int Quantity { get; set; }                
        public int NGQty { get; set; }                 
        public string NGType { get; set; }             
        public string Sheet { get; set; }               
        public string Inspector { get; set; }          
        public string QualifyNo { get; set; }         
        public string CPN2 { get; set; }                 
        public int DeviceId { get; set; }                
        public DateTime EnterTime { get; set; }          
        public string MILotNo { get; set; }             
        public string PackageNo { get; set; }            
        public float VacuumVal { get; set; }            
        public string Label { get; set; }
    }
}
