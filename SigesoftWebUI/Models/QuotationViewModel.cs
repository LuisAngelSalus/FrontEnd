using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWebUI.Models
{
    public class ProfileComponent
    {
        public string ProfileComponentId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string MinPrice { get; set; }
        public string PriceList { get; set; }
        public string SalePrice { get; set; }
        public string RecordType { get; set; }
        public string RecordStatus { get; set; }
    }

    public class QuotationProfile
    {
        public string QuotationProfileId { get; set; }
        public string ProfileName { get; set; }
        public string ServiceTypeId { get; set; }
        public List<ProfileComponent> ProfileComponents { get; set; }
        public string RecordType { get; set; }
        public string RecordStatus { get; set; }
    }

    public class AdditionalComponentsQuote
    {
        public string quotationId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string MinPrice { get; set; }
        public string PriceList { get; set; }
        public string RecordType { get; set; }
        public string RecordStatus { get; set; }
        public int InsertUserId { get; set; }
    }

    public class RootObject
    {
        public string QuotationId { get; set; }
        public string Code { get; set; }
        public int Version { get; set; }
        public int UserCreatedId { get; set; }
        public string UserName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyHeadquarterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommercialTerms { get; set; }
        public int InsertUserId { get; set; }
        public string TotalQuotation { get; set; }
        public string StatusQuotationId { get; set; }
        public List<QuotationProfile> QuotationProfiles { get; set; }
        public List<AdditionalComponentsQuote> AdditionalComponentsQuotes { get; set; }
    }
}