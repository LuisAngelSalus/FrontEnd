using BE;
using SigesoftWebUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils;

namespace SigesoftWebUI.Repositories
{
    public class WarehouseRepository
    {
        private readonly RestClient restClient = new RestClient();

        public Response<List<WarehouseDto>> GetAll(SessionModel sessionModel)
        {
            Response<List<WarehouseDto>> response = null;
            var responseClient = restClient.GetAsync<Response<List<WarehouseDto>>>("Warehouse/", sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<WarehouseDto> GetById(int id, SessionModel sessionModel)
        {
            Response<WarehouseDto> response = null;
            var urlClient = string.Format("Warehouse/{0}", id);
            var responseClient = restClient.GetAsync<Response<WarehouseDto>>(urlClient, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<WarehouseDto> Post(WarehouseDto warehouseDto, SessionModel sessionModel)
        {
            Response<WarehouseDto> response = null;
            var responseClient = restClient.PostAsync<Response<WarehouseDto>>("Warehouse/", warehouseDto, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<WarehouseDto> Put(WarehouseDto warehouseDto, SessionModel sessionModel)
        {
            Response<WarehouseDto> response = null;
            var urlClient = string.Format("Warehouse/{0}", warehouseDto.WarehouseId);
            var responseClient = restClient.PutAsync<Response<WarehouseDto>>(urlClient, warehouseDto, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }

        public Response<bool> Delete(int id, SessionModel sessionModel)
        {
            Response<bool> response = null;
            var urlClient = string.Format("Warehouse/{0}", id);
            var responseClient = restClient.DeleteAsync<Response<bool>>(urlClient, sessionModel);
            if (responseClient.IsSuccess)
            {
                response = responseClient;
            }
            return response;
        }



    }
}