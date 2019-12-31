using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BE
{
   public class CompanyHeadquarterDto
    {
        public int CompanyHeadquarterId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; } 
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; } 
    }
}
