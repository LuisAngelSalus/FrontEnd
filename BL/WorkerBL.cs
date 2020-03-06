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
   public class WorkerBL
    {
        Global _global = new Global();

        public Response<WorkerDto> GetDataWorker(int systemUserId, string token)
        {
            Response<WorkerDto> obj = null;
            var hCliente = _global.rspClientGET("Worker/" + systemUserId + "/ObtenerDataTrabajador", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<WorkerDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<WorkerDto> UpdateWorkerData(WorkerDto data, string token )
        {
            Response<WorkerDto> obj = null;
            var hCliente = _global.rspClient("Worker/ActualizarDataTrabajador", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<WorkerDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
        
    }
}
