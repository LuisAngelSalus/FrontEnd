using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EmailSenderOptions
    {
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
    }

    public class EmailDto
    {
        public string to { get; set; }
        public string body { get; set; }
        public string subject { get; set; }      
    }

    
}
