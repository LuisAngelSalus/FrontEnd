using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SigesoftWebUI.ViewModels
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "RUC")]
        //[MaxLength(11, ErrorMessage = "Máximo 11 caractéres")]
        //[MinLength(11, ErrorMessage = "Minimo 11 caractéres")]
        //[RegularExpression(@"^(?:(9)[0-9]{8}|)$", ErrorMessage = "Debe tener 11 dígitos")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public string IdentificationNumber { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Teléfono Contacto")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Contacto")]
        public string ContactName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "No es un correo válido")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "No es un correo válido")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caractéres")]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "Distrito")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Teléfono Empresa")]
        public string PhoneCompany { get; set; }


        //public int ResponsibleSystemUserId { get; set; }
        public HttpPostedFileBase File { get; set; }
        //public int InsertUserId { get; set; }
    }
}