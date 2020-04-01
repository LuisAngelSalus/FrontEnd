using BE;
using SigesoftWebUI.Utils;
using SigesoftWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils;

namespace SigesoftWebUI.Repositories
{
    public class CompanyRepository
    {
        private readonly RestClient restClient = new RestClient();

        public Response<List<ListCompanyDto>> Companies(ParamsCompanyFilterModel data, SessionModel sessionModel)
        {
            Response<List<ListCompanyDto>> response = null;
            var responseClient = restClient.PostAsync<Response<List<ListCompanyDto>>>("Company/Filter", data, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<CompanyViewModel> CompanyDetail(int companyId, SessionModel sessionModel)
        {
            Response<CompanyViewModel> response = null;
            var urlClient = string.Format("Company/{0}/sedes", companyId);
            var responseClient = restClient.GetAsync<Response<CompanyViewModel>>(urlClient, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<CompanyViewModel> Save(CompanyViewModel data, SessionModel sessionModel)
        {
            Response<CompanyViewModel> response = null;
            if (data.CompanyId != 0)
            {
                var urlClient = string.Format("Company/{0}", data.CompanyId);
                var responseClient = restClient.PutAsync<Response<CompanyViewModel>>(urlClient, data, sessionModel);
                if (responseClient.IsSuccess)
                {
                    response = responseClient;
                }
                return response;
            }
            else
            {
                var responseClient = restClient.PostAsync<Response<CompanyViewModel>>("Company/", data, sessionModel);
                if (responseClient.IsSuccess)
                {
                    response = responseClient;
                }
                return response;
            }
        }

    }
}