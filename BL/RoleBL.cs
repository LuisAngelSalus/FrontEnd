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
   public class RoleBL
    {
        Global _global = new Global();
        public Response<List<ListRoleDto>> Roles(string token)
        {
            Response<List<ListRoleDto>> obj = null;
            var hCliente = _global.rspClientGET("Role", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListRoleDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
