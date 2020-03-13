using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class AdditionalComponentsModel
    {
        public string ComponentId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
