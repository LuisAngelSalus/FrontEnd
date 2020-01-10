using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class QuoteTrackingUpdateDto
    {
        public int QuoteTrackingId { get; set; }
        public int QuotationId { get; set; }        
        public string Commentary { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
