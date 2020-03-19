using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ListComponentDto
    {
        public string ComponentId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public float? CostPrice { get; set; }
        public float? BasePrice { get; set; }
        public float? SalePrice { get; set; }
    }

    public class ListComponentForScheduleDto
    {
        public string ComponentId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public float? SalePrice { get; set; }
    }
}
