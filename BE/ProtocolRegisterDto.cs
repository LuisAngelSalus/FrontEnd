using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ProtocolRegisterDto
    {
        public int CompanyId { get; set; }
        public string ProtocolName { get; set; }
        public int ServiceTypeId { get; set; }
        public int TypeFormatId { get; set; }
        public int QuotationProfileIdRef { get; set; }
    }
    public class ProtocolDetailRegisterDto
    {
        public int ProtocolId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal PriceList { get; set; }
        public decimal SalePrice { get; set; }
        public int AgeConditionalId { get; set; }
        public int Age { get; set; }
        public int GenderConditionalId { get; set; }
        public int QuotationProfileIdRef { get; set; }

    }
}
