using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWebUI.Models
{
    public class SessionModel
    {
        public int SystemUserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }

    }
}