using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class ProtocolProfileDto
    {
        public int ProtocolProfileId { get; set; }
        public string ProtocolProfileName { get; set; }
        public List<CategoryDto> categories { get; set; }
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProfileDetailDto> Detail { get; set; }
    }

    public class ProfileDetailDto
    {
        public bool Active { get; set; }
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public float? CostPrice { get; set; }
        public float? BasePrice { get; set; }
        public float? SalePrice { get; set; }
    }
}
