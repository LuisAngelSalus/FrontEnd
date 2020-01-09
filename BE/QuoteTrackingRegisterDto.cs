using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class QuoteTrackingRegisterDto
    {
        public int QuotationId { get; set; }
        public string Commentary { get; set; }
        public int InsertUserId { get; set; }
    }
}
