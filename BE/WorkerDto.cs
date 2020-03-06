using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class WorkerDto
    {
        public int? WorkerId { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string CurrentPosition { get; set; }
        public string HomeAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? GenderId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int TypeDocumentId { get; set; }
        public string NroDocument { get; set; }
    }
}
