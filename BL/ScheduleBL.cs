using BE;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utils;

namespace BL
{
    public class ScheduleBL
    {
        Global _global = new Global();
        WorkerBL _workerBL = new WorkerBL();
        ProtocolBL _protocolBL = new ProtocolBL();

        public List<ScheduleExcelImportDto> Read (byte[] bytes, string token)
        {           
            MemoryStream stream = new MemoryStream(bytes);
            var list = new List<ScheduleExcelImportDto>();
            IWorkbook book = new XSSFWorkbook(stream);
            ISheet Sheet = book.GetSheet(book.GetSheetName(0));
            int index = 3;            

            bool finArchivo = false;
            while (!finArchivo)
            {
                try
                {
                    index++;
                    IRow Row = Sheet.GetRow(index);
                    if (Row != null)
                    {
                        var row = new ScheduleExcelImportDto();
                        row.DateSchedule = Row.GetCell(1) != null ? Row.GetCell(1).ToString() : "";
                        row.DocumentTypeName = Row.GetCell(2) != null ? Row.GetCell(2).ToString() : "";
                        row.DocumentNumber = Row.GetCell(3) != null ? Row.GetCell(3).ToString() : "";
                        row.FirstName= Row.GetCell(4) != null ? Row.GetCell(4).ToString() : "";
                        row.FirstLastName = Row.GetCell(5) != null ? Row.GetCell(5).ToString() : "";
                        row.SecondLastName = Row.GetCell(6) != null ? Row.GetCell(6).ToString() : "";
                        row.Gender = Row.GetCell(7) != null ? Row.GetCell(7).ToString() : "";
                        row.CurrentOccupation = Row.GetCell(8) != null ? Row.GetCell(8).ToString() : "";
                        row.MobileNumber = Row.GetCell(12) != null ? Row.GetCell(12).ToString() : "";
                        row.Email = Row.GetCell(13) != null ? Row.GetCell(13).ToString() : "";
                        list.Add(row);
                    }
                    else
                    {
                        finArchivo = true;
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            
            return list;
        }

        public Response<List<ListComponentForScheduleDto>> GetByName(string value, string token)
        {
            Response<List<ListComponentForScheduleDto>> obj = null;
            var hCliente = _global.rspClientGET("ComponentWin/" + value, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListComponentForScheduleDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<AdditionalComponentsModel>> GetAdditionalComponents(int protocolId, string token)
        {
            Response<List<AdditionalComponentsModel>> obj = null;
            var hCliente = _global.rspClientGET("Protocol/"+ protocolId + "/ExamenesAdicionales", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<AdditionalComponentsModel>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> Schedule(List<ScheduleDto> scheduleDtos, string token)
        {
            List<ScheduleRegisterDto> listSchedule = new List<ScheduleRegisterDto>();  
            foreach (var schedule in scheduleDtos)
            {
                var ScheduleRegister = new ScheduleRegisterDto();

                ScheduleRegister.DateTimeCalendar = schedule.dateSchedule;
                ScheduleRegister.CalendarStatusId = CalendarStatus.NoIniciado;
                ScheduleRegister.IsVipId = YesNo.No;
                ScheduleRegister.MoodId = Mood.Normal;

                ScheduleRegister.Service.ProtocolId = schedule.protocolId;

                var worker = _workerBL.GetDataWorker(schedule.nroDoc, token);
                if (worker.IsSuccess)
                {
                    ScheduleRegister.Service.WorkerId = worker.Data.WorkerId.Value;
                }
                else
                {
                    var oWorkerRegisterDto = new WorkerRegisterDto();
                    oWorkerRegisterDto.CurrentPosition = schedule.currentOcupation;
                    oWorkerRegisterDto.HomeAddress = string.Empty;
                    oWorkerRegisterDto.DateOfBirth = DateTime.Now;
                    oWorkerRegisterDto.GenderId = schedule.genderType;
                    oWorkerRegisterDto.Email = schedule.email;
                    oWorkerRegisterDto.MobileNumber = schedule.cell;
                    oWorkerRegisterDto.TypeDocumentId = schedule.docType;
                    oWorkerRegisterDto.NroDocument = schedule.nroDoc;

                    var oPersonRegistertDto = new PersonRegistertDto();
                    oPersonRegistertDto.FirstName = schedule.firstName;
                    oPersonRegistertDto.FirstLastName = schedule.firstLastName;
                    oPersonRegistertDto.SecondLastName = schedule.secondLastName;
                    oWorkerRegisterDto.Person = oPersonRegistertDto;

                    _workerBL.Save(oWorkerRegisterDto, token);
                }

                ScheduleRegister.Service.ServiceStatusId = ServiceStatus.PorIniciar;

                var protocolDetail = _protocolBL.GetById(schedule.protocolId, token).Data.ProtocolDetail;

                var Detail = new List<ServiceComponentRegisterDto>();
                foreach (var detailDto in protocolDetail)
                {
                    var oServiceComponentRegisterDto = new ServiceComponentRegisterDto();
                    oServiceComponentRegisterDto.ComponentId = detailDto.ComponentId;
                    oServiceComponentRegisterDto.ServiceComponentStatusId = ServiceComponentStatus.PorIniciar;
                    Detail.Add(oServiceComponentRegisterDto);
                }

                ScheduleRegister.Service.ServiceComponent = Detail;

                listSchedule.Add(ScheduleRegister);
            }

            Response<bool> obj = null;
            var hCliente = _global.rspClient("Schedule/", listSchedule, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
