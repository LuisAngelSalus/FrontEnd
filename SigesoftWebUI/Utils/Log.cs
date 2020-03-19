using System;

namespace SigesoftWebUI.Utils
{
    public class Log
    {
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public DateTime? LogDate { get; set; }
        public string IdUser { get; set; }
        public string DBEntityException { get; set; }
    }
}