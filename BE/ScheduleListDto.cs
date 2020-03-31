using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ScheduleListDto
    {
        public int ScheduleId { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerCell { get; set; }
        public string ProtocolName { get; set; }
        public string CurrentOccupation { get; set; }
        public string NroDocument { get; set; }
    }

    public class ParamsSearch
    {
        public string Value { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class ScheduleDataModel
    {
        public ScheduleDataModel()
        {
            ScheduleComponents = new List<ScheduleComponent>();
        }
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime DateBirth { get; set; }
        public int DocType { get; set; }
        public string NroDocument { get; set; }
        public int GenderId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ProtocolName { get; set; }
        public string CompanyName { get; set; }
        public DateTime ServiceDate { get; set; }
        public List<ScheduleComponent> ScheduleComponents { get; set; }

    }

    public class ScheduleComponent
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
    }
}
