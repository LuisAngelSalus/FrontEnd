using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class SystemUserDto
    {
        public int SystemUserId { get; set; }
        public int? PersonId { get; set; }
        public string UserName { get; set; }
    }
}
