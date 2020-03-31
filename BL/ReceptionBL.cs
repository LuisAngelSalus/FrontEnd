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
    public class ReceptionBL
    {
        Global _global = new Global();

        public Response<List<ScheduleListDto>> Search(ParamsSearch data, string token)
        {
            Response<List<ScheduleListDto>> obj = null;

            var hCliente = _global.rspClient("Schedule/Buscar", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ScheduleListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ScheduleDataModel> GetDataSchedule(int scheduleId, string token)
        {
            Response<ScheduleDataModel> obj = null;

            var hCliente = _global.rspClientGET("Schedule/DataCita/" + scheduleId,token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ScheduleDataModel>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}

