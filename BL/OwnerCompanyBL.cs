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
   public class OwnerCompanyBL
    {
        Global _global = new Global();
        public Response<List<ListOwnerCompanyDto>> OwnerCompanies(string token)
        {
            Response<List<ListOwnerCompanyDto>> obj = null;
            var hCliente = _global.rspClientGET("OwnerCompany", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListOwnerCompanyDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
