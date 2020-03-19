using BE;
using System.Collections.Generic;

namespace SigesoftWebUI.Models
{
    public class ModelCompanyDetail
    {
        public ModelCompanyDetail()
        {
            companyHeadquarter = new List<CompanyHeadquarterDto>();
        }

        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactName { get; set; }
        public string Mail { get; set; }

        public string District { get; set; }
        public string PhoneCompany { get; set; }

        public List<CompanyHeadquarterDto> companyHeadquarter { get; set; }
    }
}