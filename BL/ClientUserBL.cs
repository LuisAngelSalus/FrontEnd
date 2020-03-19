using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utils;

namespace BL
{
    public class ClientUserBL
    {
        Global _global = new Global();

        public Response<ClientUserDto> GetById(int clientUserId, string token)
        {
            Response<ClientUserDto> obj = null;
            var hCliente = _global.rspClientGET("ClientUser/" + clientUserId , token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ClientUserDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<ClientUserDto>> GetAllAsyncByCompany(int companyId, string token)
        {
            Response<List<ClientUserDto>> obj = null;
            var hCliente = _global.rspClientGET("ClientUser/" + companyId + "/UsuariosClientes", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ClientUserDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ClientUserDto> Save(ClientUserRegisterDto data, string token)
        {
            Response<ClientUserDto> obj = null;
            var hCliente = _global.rspClient("ClientUser/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ClientUserDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ClientUserDto> Update(ClientUserUpdateDto data, string token)
        {
            Response<ClientUserDto> obj = new Response<ClientUserDto>();
            var hCliente = _global.rspClientPUT("ClientUser/" + data.ClientUserId, data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ClientUserDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public bool ChangePassword(ClientUserPasswordDto data, string token)
        {
            var hCliente = _global.rspClient("ClientUser/cambiarcontrasena", data, token);
            return true;
        }

        public Response<CompanyDetailDto> UpdateCompany(CompanyDetailDto data, string token)
        {
            Response<CompanyDetailDto> obj = null;
            var hCliente = _global.rspClientPUT("ClientUser/" + data.CompanyId + "/actualizarEmpresa", data, token);

            if (hCliente.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }

            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
