using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BE
{
    public class ScheduleRegisterDto
    {
        public ScheduleRegisterDto()
        {
            Service = new ServiceRegisterDto();
        }

        public DateTime DateTimeCalendar { get; set; }
        public CalendarStatus CalendarStatusId { get; set; }
        public YesNo IsVipId { get; set; }
        public Mood MoodId { get; set; }
        public ServiceRegisterDto Service { get; set; }
    }

    public class ServiceRegisterDto
    {
        public ServiceRegisterDto()
        {
            ServiceComponent = new HashSet<ServiceComponentRegisterDto>();
        }
        public int ProtocolId { get; set; }
        public int WorkerId { get; set; }
        public ServiceStatus ServiceStatusId { get; set; }
        public ICollection<ServiceComponentRegisterDto> ServiceComponent { get; set; }
    }

    public class ServiceComponentRegisterDto
    {
        public string ComponentId { get; set; }
        public ServiceComponentStatus ServiceComponentStatusId { get; set; }
    }

    public class ScheduleDto
    {
        public DateTime dateSchedule { get; set; }
        public int docType { get; set; }
        public string nroDoc { get; set; }
        public string firstName { get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public int genderType { get; set; }
        public string currentOcupation { get; set; }
        public string protocolName { get; set; }
        public string compFact { get; set; }
        public string compResult { get; set; }
        public string cell { get; set; }
        public string email { get; set; }
        public int protocolId { get; set; }
        public List<ExaAddi> exaAddi { get; set; }
    }

    public class ExaAddi {
        public string id { get; set; }
        public string text { get; set; }
    }
}
