using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RegisterAccessDto
    {
        public int UserId { get; set; }
        public int OwnerCompanyId { get; set; }
        public int[] Roles { get; set; }
        public int UpdateUserId { get; set; }
    }
}
