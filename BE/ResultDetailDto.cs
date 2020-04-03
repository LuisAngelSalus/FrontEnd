using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ResultDetailDto
    {
        public int i_ServiceComponentId { get; set; }
        public int i_ServiceId { get; set; }
        public string v_ComponentId { get; set; }
        [Display(Name = "Examen")]
        public string v_Name { get; set; }
        [Display(Name = "Estado")]
        public int i_ServiceComponentStatusId { get; set; }
    }
}
