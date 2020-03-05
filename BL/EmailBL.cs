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
        Global _global = new Global();

        public void SendMail(EmailDto data)
        {
            var hCliente = _global.rspClient("Email/", data);
        }

    }
}
