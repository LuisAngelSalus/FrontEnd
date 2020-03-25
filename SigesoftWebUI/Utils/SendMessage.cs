using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigesoftWebUI.Utils
{
    public class SendMessage
    {
        public List<AttachDto> attaches { get; set; }

        public string FirstNameDocument { get; set; }
        public string SecondNameDocument { get; set; }

        public SendMessage()
        {
            attaches = new List<AttachDto>();
        }
    }
}