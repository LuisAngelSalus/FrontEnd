using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class QuotationDto
    {
        public QuotationDto()
        {
            QuotationProfiles = new List<QuotationProfileDto>();
        }
        public int QuotationId { get; set; }
        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyRuc { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDistrictName { get; set; }
        public string CompanyAddress { get; set; }
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int TypeFormatId { get; set; }
        public string CommercialTerms { get; set; }
        public int? InsertUserId { get; set; }
        public List<QuotationProfileDto> QuotationProfiles { get; set; }
    }

    public class QuotationProfileDto
    {
        public QuotationProfileDto()
        {
            ProfileComponents = new List<ProfileComponentDto>();
        }
        public int QuotationProfileId { get; set; }
        public int QuotationId { get; set; }
        public int? ProfileId { get; set; }
        public string ProfileName { get; set; }
        public int? ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int? InsertUserId { get; set; }
        public List<ProfileComponentDto> ProfileComponents { get; set; }
    }

    public class ProfileComponentDto
    {
        public int ProfileComponentId { get; set; }
        public int QuotationProfileId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? InsertUserId { get; set; }
    }


    #region Register

    public class QuotationRegisterDto
    {
        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }        
        public int CompanyId { get; set; }        
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int TypeFormatId { get; set; }
        public string CommercialTerms { get; set; }
        public int? InsertUserId { get; set; }
        public List<QuotationProfileRegisterDto> QuotationProfiles { get; set; }
    }

    public class QuotationProfileRegisterDto
    {
        public int QuotationId { get; set; }
        //public int? ProfileId { get; set; }
        public string ProfileName { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? InsertUserId { get; set; }
        public List<ProfileComponentRegisterDto> ProfileComponents { get; set; }
    }

    public class ProfileComponentRegisterDto
    {
        public int QuotationProfileId { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? InsertUserId { get; set; }
    }

    #endregion
}
