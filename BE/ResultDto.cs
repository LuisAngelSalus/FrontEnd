using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ResultDto
    {
        public int i_ServiceId { get; set; }
        [Display(Name ="F. Programación")]
        public DateTime d_ServiceDate { get; set; }
        public int i_ProtocolId { get; set; }
        [Display(Name = "Protocolo")]
        public string v_ProtocolName { get; set; }
        public int i_PersonId { get; set; }
        public string v_FirstName { get; set; }
        public string v_FirstLastName { get; set; }
        public string v_SecondLastName { get; set; }
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }
        public int i_CompanyId { get; set; }
        [Display(Name = "Empresa Trab.")]
        public string v_Name { get; set; }
        [Display(Name = "Puesto")]
        public string v_CurrentPosition { get; set; }
        [Display(Name = "Estado")]
        public int i_ServiceStatusId { get; set; }
        public string ServiceStatusClass { get; set; }
        public string v_ValueService { get; set; }
        public int i_AptitudeStatusId { get; set; }
        [Display(Name = "Aptitud")]
        public string v_ValueAptitude { get; set; }
    }
}
