using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ScheduleListDto
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerCell { get; set; }
        public string ProtocolName { get; set; }
        public string CurrentOccupation { get; set; }
    }

    public class ParamsSearch
    {
        public string Value { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
