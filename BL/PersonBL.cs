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

        public Response<PersonDto> Save(PersonRegistertDto data, string token)
        {
            Response<PersonDto> obj = null;
            var hCliente = _global.rspClient("People/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<PersonDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<PersonUpdateDto> Update(PersonUpdateDto data, string token)
        {
            Response<PersonUpdateDto> obj = new Response<PersonUpdateDto>();
            var hCliente = _global.rspClientPUT("People/"+data.PersonId, data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<PersonUpdateDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
