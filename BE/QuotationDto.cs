using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BE
{

    #region Select

    public class QuotationDto
    {
        public QuotationDto()
        {
            QuotationProfile = new List<QuotationProfileDto>();
            AdditionalComponentsQuote = new List<AdditionalComponentsQuoteDto>();
        }

        public int QuotationId { get; set; }
        public string Code { get; set; }
        public string Version { get; set; }
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
        public int StatusQuotationId { get; set; }
        public decimal? TotalQuotation { get; set; }
        public int? InsertUserId { get; set; }
        public List<QuotationProfileDto> QuotationProfile { get; set; }
        public List<AdditionalComponentsQuoteDto> AdditionalComponentsQuote { get; set; }
    }

    public class QuotationProfileDto
    {
        public QuotationProfileDto()
        {
            ProfileComponent = new List<ProfileComponentDto>();
        }

        public int QuotationProfileId { get; set; }
        public int QuotationId { get; set; }
        public string ProfileName { get; set; }
        public int? ServiceTypeId { get; set; }
        public int TypeFormatId { get; set; }
        public string ServiceTypeName { get; set; }
        public int? InsertUserId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
        public List<ProfileComponentDto> ProfileComponent { get; set; }
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
        public int? AgeConditionalId { get; set; }
        public int? Age { get; set; }
        public int? GenderConditionalId { get; set; }
        public int? InsertUserId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
    }

    public class AdditionalComponentsQuoteDto
    {
        public int AdditionalComponentsQuoteId { get; set; }
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
    #endregion

    #region Register

    public class QuotationRegisterDto
    {
        public QuotationRegisterDto()
        {
            QuotationProfile = new List<QuotationProfileRegisterDto>();
            AdditionalComponentsQuote = new List<AdditionalComponentsQuoteRegisterDto>();
        }
        public int QuotationId { get; set; }
        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDistrictName { get; set; }
        public string CompanyAddress { get; set; }
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommercialTerms { get; set; }
        public int StatusQuotationId { get; set; }
        public decimal? TotalQuotation { get; set; }
        public int? InsertUserId { get; set; }
        public List<QuotationProfileRegisterDto> QuotationProfile { get; set; }
        public List<AdditionalComponentsQuoteRegisterDto> AdditionalComponentsQuote { get; set; }
    }

    public class QuotationProfileRegisterDto
    {
        public QuotationProfileRegisterDto()
        {
            ProfileComponent = new List<ProfileComponentRegisterDto>();
        }

        public int QuotationId { get; set; }
        public string ProfileName { get; set; }
        public int? ServiceTypeId { get; set; }
        public int TypeFormatId { get; set; }
        public string ServiceTypeName { get; set; }
        public int? InsertUserId { get; set; }
        public List<ProfileComponentRegisterDto> ProfileComponent { get; set; }
    }

    public class ProfileComponentRegisterDto
    {
        public int QuotationProfileId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? AgeConditionalId { get; set; }
        public int? Age { get; set; }
        public int? GenderConditionalId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public int? InsertUserId { get; set; }
    }

    public class AdditionalComponentsQuoteRegisterDto
    {
        public int QuotationId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? InsertUserId { get; set; }
    }

    #endregion  

    #region Update
    public class QuotationUpdateDto
    {
        public QuotationUpdateDto()
        {
            QuotationProfile = new List<QuotationProfileUpdateDto>();
            AdditionalComponentsQuote = new List<AdditionalComponentsQuoteUpdateDto>();
        }

        public int QuotationId { get; set; }
        public string Code { get; set; }
        public int Version { get; set; }
        public int CompanyId { get; set; }
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommercialTerms { get; set; }
        public int StatusQuotationId { get; set; }
        public decimal? TotalQuotation { get; set; }
        public int? UpdateUserId { get; set; }
        public List<QuotationProfileUpdateDto> QuotationProfile { get; set; }
        public List<AdditionalComponentsQuoteUpdateDto> AdditionalComponentsQuote { get; set; }
    }
    public class AdditionalComponentsQuoteUpdateDto
    {
        public int QuotationId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? AgeConditionalId { get; set; }
        public int? Age { get; set; }
        public int? GenderConditionalId { get; set; }
        public int? InsertUserId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
    }
    public class QuotationProfileUpdateDto
    {
        public QuotationProfileUpdateDto()
        {
            ProfileComponent = new List<ProfileComponentUpdateDto>();
        }

        public int QuotationProfileId { get; set; }
        public int QuotationId { get; set; }
        public int? ServiceTypeId { get; set; }
        public int TypeFormatId { get; set; }
        public string ProfileName { get; set; }
        public int? UpdateUserId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public RecordType RecordType { get; set; }
        public List<ProfileComponentUpdateDto> ProfileComponent { get; set; }
    }
    public class ProfileComponentUpdateDto
    {
        public int ProfileComponentId { get; set; }
        public int QuotationProfileId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? SalePrice { get; set; }
        public int? UpdateUserId { get; set; }
        public int? AgeConditionalId { get; set; }
        public int? Age { get; set; }
        public int? GenderConditionalId { get; set; }
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
        public int[] StatusQuotationId { get; set; }
    }

    public class QuotationFilterDto
    {
        public QuotationFilterDto()
        {
            QuoteTracking = new List<QuoteTrackingFilterDto>();
        }

        public int QuotationId { get; set; }
        public string NroQuotation { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string CompanyName { get; set; }
        public decimal Total { get; set; }
        public DateTime? USDate { get; set; }
        public string TrackingDescription { get; set; }
        public int StatusQuotationId { get; set; }
        public string StatusQuotationName { get; set; }
        public string Indicator { get; set; }
        public List<QuoteTrackingFilterDto> QuoteTracking { get; set; }
    }
    public class QuoteTrackingFilterDto
    {
        public int QuoteTrackingId { get; set; }
        public int QuotationId { get; set; }
        public int Version { get; set; }
        public DateTime? Date { get; set; }
        public string Commentary { get; set; }
        public string StatusName { get; set; }
    }
    #endregion

    #region NEW VERSION

    public class QuotationNewVersionDto
    {
        public QuotationNewVersionDto()
        {
            QuotationProfile = new List<QuotationProfileNewVersionDto>();
            AdditionalComponentsQuote = new List<AdditionalComponentsQuoteNewVersionDto>();
        }

        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDistrictName { get; set; }
        public string CompanyAddress { get; set; }
        public int CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommercialTerms { get; set; }
        public int StatusQuotationId { get; set; }
        public decimal? TotalQuotation { get; set; }
        public int? InsertUserId { get; set; }
        public List<QuotationProfileNewVersionDto> QuotationProfile { get; set; }
        public List<AdditionalComponentsQuoteNewVersionDto> AdditionalComponentsQuote { get; set; }
    }

    public class QuotationProfileNewVersionDto
    {
        public QuotationProfileNewVersionDto()
        {
            ProfileComponent = new List<ProfileComponentNewVersionDto>();
        }

        public string ProfileName { get; set; }
        public int? ServiceTypeId { get; set; }
        public int TypeFormatId { get; set; }
        public string ServiceTypeName { get; set; }
        public int? InsertUserId { get; set; }
        public List<ProfileComponentNewVersionDto> ProfileComponent { get; set; }
    }

    public class ProfileComponentNewVersionDto
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? AgeConditionalId { get; set; }
        public int? Age { get; set; }
        public int? GenderConditionalId { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public int? InsertUserId { get; set; }
    }

    public class AdditionalComponentsQuoteNewVersionDto
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceList { get; set; }
        public decimal? SalePrice { get; set; }
        public int? InsertUserId { get; set; }
    }


    #endregion

    public class QuotationVersionDto
    {
        public int QuotationId { get; set; }
        public string NroQuotation { get; set; }
        public int Version { get; set; }
        public YesNo IsProccess { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string CompanyName { get; set; }
        public decimal Total { get; set; }
        public DateTime? USDate { get; set; }
        public string TrackingDescription { get; set; }
        public int StatusQuotationId { get; set; }
        public string StatusQuotationName { get; set; }

    }

    public class QuotationUpdateProcess
    {
        public int QuotationId { get; set; }
        public string Code { get; set; }
    }

    public class QuotationMigrateDto
    {
        public int QuotationId { get; set; }
    }
}
