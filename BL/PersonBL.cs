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
   public class PersonBL
    {
        Global _global = new Global();

        public Response<PersonDto> GetPerson(int personId, string token)
        {
            Response<PersonDto> obj = null;
            var hCliente = _global.rspClientGET("People/" + personId, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<PersonDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
