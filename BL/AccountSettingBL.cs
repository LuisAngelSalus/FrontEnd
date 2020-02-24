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
   public class AccountSettingBL
    {
        Global _global = new Global();

        public Response<ListAccountSettingDto> GetAccountSettingBySystemUserId(int systemUserId, string token)
        {
            Response<ListAccountSettingDto> obj = null;
            var hCliente = _global.rspClientGET("AccountSetting/" + systemUserId + "/configuracionCuenta", token);
            if (hCliente.StatusCode == System.Net.HttpStatusCode.NotFound) {
                
                obj = new JavaScriptSerializer().Deserialize<Response<ListAccountSettingDto>>(hCliente.Content.ReadAsStringAsync().Result);                
            }

            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ListAccountSettingDto>>(hCliente.Content.ReadAsStringAsync().Result);                
            }
            return obj;
        }
        
        public Response<ListAccountSettingDto> Save(AccountSettingRegisterDto data, string token)
        {
            Response<ListAccountSettingDto> obj = null;
            
            var hCliente = _global.rspClient("AccountSetting/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ListAccountSettingDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
            
        }

        public Response<ListAccountSettingDto> Update(AccountSettingUpdateDto data, string token)
        {
            Response<ListAccountSettingDto> obj = new Response<ListAccountSettingDto>();
            var hCliente = _global.rspClientPUT("AccountSetting/" + data.AccountSettingId, data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ListAccountSettingDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
