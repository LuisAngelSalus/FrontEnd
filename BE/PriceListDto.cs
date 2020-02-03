using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class PriceListDto
    {
        public int CompanyId { get; set; }
        public string ComponentId { get; set; }
        public decimal Price { get; set; }
        public int? InsertUserId { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
