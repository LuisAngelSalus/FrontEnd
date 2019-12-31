using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class ValidatedAccessDto
    {
        public int SystemUserId { get; set; }
        public string Token { get; set; }
    }
}