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

        public ClientSession UserAccess(int id, string token)
        {
            ClientSession obj = null;
            var hCliente = _global.rspClientGET("SystemUser/"+id + "/accesousuario",token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<ClientSession>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
