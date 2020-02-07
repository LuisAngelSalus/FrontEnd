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
    public class SecurityBL
    {
        Global _global = new Global();
        public ValidatedAccessDto ValidateAccess(LoginDto oLoginDto)
        {
            ValidatedAccessDto obj = null;
            var hCliente = _global.rspClient("Session/Login", oLoginDto);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<ValidatedAccessDto>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public SessionModel UserAccess(int id, string token)
        {
            SessionModel obj = null;
            var hCliente = _global.rspClientGET("SystemUser/"+id + "/accesousuario",token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<SessionModel>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<SystemUserDto>> GetAllSystemUser(string token)
        {
            Response<List<SystemUserDto>> obj = null;
            var hCliente = _global.rspClientGET("SystemUser/", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<SystemUserDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<GetSystemUserDto> GetSystemUser(int userId,string token)
        {
            Response<GetSystemUserDto> obj = null;            
            var hCliente = _global.rspClientGET("SystemUser/"+ userId, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<GetSystemUserDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<SystemUserRegisterDto> Save(SystemUserRegisterDto data, string token)
        {
            Response<SystemUserRegisterDto> obj = null;
            var hCliente = _global.rspClient("SystemUser/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<SystemUserRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<SystemUserUpdateDataDto> Update(SystemUserUpdateDataDto data, string token)
        {
            Response<SystemUserUpdateDataDto> obj = new Response<SystemUserUpdateDataDto>();
            var hCliente = _global.rspClientPUT("SystemUser/"+ data.SystemUserId, data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<SystemUserUpdateDataDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> SaveAccess(List<RegisterAccessDto> data, string token)
        {
            Response<bool> obj = null;
            var hCliente = _global.rspClient("SystemUser/actualizarAccesos/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            
            return obj;
        }
    }
}
