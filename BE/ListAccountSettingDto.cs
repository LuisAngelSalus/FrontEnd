using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ListAccountSettingDto
    {
        public int AccountSettingId { get; set; }
        public int SystemUserId { get; set; }
        public int OwnerCompanyId { get; set; }
        public int RoleId { get; set; }
    }
}
