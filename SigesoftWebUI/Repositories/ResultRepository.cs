using BE;
using SigesoftWebUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils;

namespace SigesoftWebUI.Repositories
{
    public class ResultRepository
    {
        private readonly RestClient restClient = new RestClient();

        public Response<List<ResultDto>> GetResults(SessionModel sessionModel)
        {
            Response<List<ResultDto>> response = null;

            var responseClient = restClient.GetAsync<Response<List<ResultDto>>>("Results/", sessionModel);

            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }

            return response;
        }


        public Response<List<ResultDetailDto>> GetResultsDetail(int id, SessionModel sessionModel)
        {
            Response<List<ResultDetailDto>> response = null;
            var urlClient = string.Format("Results/Detail/{0}", id);
            var responseClient = restClient.GetAsync<Response<List<ResultDetailDto>>>(urlClient, sessionModel);

            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }

            return response;
        }

    }
}