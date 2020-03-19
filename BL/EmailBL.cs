using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BL
{
    public class EmailBL
    {
        private readonly Global _global = new Global();

        public void SendMail(EmailDto data)
        {
            _global.rspClient("Email/", data);
        }

    }
}
