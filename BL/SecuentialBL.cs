using BE;
using System.Web.Script.Serialization;
using Utils;

namespace BL
{
    public class SecuentialBL
    {
        Global _global = new Global();

        public string GetSecuential(SecuentialDto data, string token)
        {
            Response<int> obj = null;

            var hCliente = _global.rspClient("Secuential/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<int>>(hCliente.Content.ReadAsStringAsync().Result);
            }

            return GenerateCode.Code(data.Process, data.SystemUserId.ToString(), obj.Data);
        }

    }
}
