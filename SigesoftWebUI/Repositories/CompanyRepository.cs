using BE;
using SigesoftWebUI.Utils;
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

        public Response<CompanyDetailDto> CompanyDetail(int companyId, SessionModel sessionModel)
        {
            Response<CompanyDetailDto> response = null;
            var urlClient = string.Format("Company/{0}/sedes", companyId);
            var responseClient = restClient.GetAsync<Response<CompanyDetailDto>>(urlClient, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<CompanyDetailDto> Save(CompanyDetailDto data, SessionModel sessionModel)
        {
            Response<CompanyDetailDto> response = null;
            if (data.CompanyId != 0)
            {
                var urlClient = string.Format("Company/{0}", data.CompanyId);
                var responseClient = restClient.PutAsync<Response<CompanyDetailDto>>(urlClient, data, sessionModel);
                if (responseClient.IsSuccess)
                {
                    response = responseClient;
                }
                return response;
            }
            else
            {
                var responseClient = restClient.PostAsync<Response<CompanyDetailDto>>("Company/", data, sessionModel);
                if (responseClient.IsSuccess)
                {
                    response = responseClient;
                }
                return response;
            }
        }

    }
}