using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

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
        public string CommercialTerms { get; set; }
        public int? StatusQuotationId { get; set; }
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
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
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
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
    }


    #region Register

    public class QuotationRegisterDto
    {
        public int QuotationId { get; set; }
        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }        
        public int CompanyId { get; set; }        
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommercialTerms { get; set; }
        public int StatusQuotationId { get; set; }
        public decimal? TotalQuotation { get; set; }
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



    #region UPDATE

    public class QuotationUpdateDto
    {
        public int QuotationId { get; set; }
        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommercialTerms { get; set; }
        public int StatusQuotationId { get; set; }
        public decimal? TotalQuotation { get; set; }
        public int? InsertUserId { get; set; }

        public List<QuotationProfileUpdateDto> QuotationProfiles { get; set; }
    }

    public class QuotationProfileUpdateDto
    {
        public int QuotationId { get; set; }
        public int? QuotationProfileId { get; set; }
        public string ProfileName { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? UpdateUserId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
        public List<ProfileComponentUpdateDto> ProfileComponents { get; set; }
    }

    public class ProfileComponentUpdateDto
    {
        public int QuotationProfileId { get; set; }
        public int ProfileComponentId { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? UpdateUserId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
    }

    #endregion


    #region Filter

    public class ParamsQuotationFilterDto
    {
        public string NroQuotation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CompanyName { get; set; }
        public int StatusQuotationId { get; set; }
    }
    public class QuotationFilterDto
    {
        public int QuotationId { get; set; }
        public string NroQuotation { get; set; }
        public string ShippingDate { get; set; }
        public string AcceptanceDate { get; set; }
        public string CompanyName { get; set; }
        public decimal Total { get; set; }
        public int StatusQuotationId { get; set; }        
        public string StatusQuotationName { get; set; }
        public string USDate { get; set; }
        public string TrackingDescription { get; set; }
        public List<QuoteTrackingFilterDto> QuoteTrackings { get; set; }
    }

    public class QuoteTrackingFilterDto
    {
        public int QuoteTrackingId { get; set; }
        public int QuotationId { get; set; }
        public string Date { get; set; }
        public string Commentary { get; set; }
    }
    #endregion
}
