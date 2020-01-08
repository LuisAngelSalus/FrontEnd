using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ProtocolProfileRegisterDto
    {
        public string Name { get; set; }
        public List<ProfileDetailRegisterDto> ProfileDetail { get; set; }
    }
    public class ProfileDetailRegisterDto
    {
        public string ComponentId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
