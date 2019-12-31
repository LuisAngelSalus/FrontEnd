using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ListCompanyContactDto
    {
        public int CompanyHeadquarterId { get; set; }
        public string CompanyHeadquarterName { get; set; }
        public string FullName { get; set; }
        public string TypeUs { get; set; }
        public string Dni { get; set; }
        public string CM { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
