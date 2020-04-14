using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BE
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        public int? CompanyId { get; set; }
        public int? CompanyHeadquarterId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int IsPrincipal { get; set; }
        public int IsDeleted { get; set; }
    }
}
