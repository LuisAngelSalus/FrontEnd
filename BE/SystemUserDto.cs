using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class GetSystemUserDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    public class SystemUserRegisterDto
    {
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        //[RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{1,63}$")]
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class SystemUserUpdateDataDto
    {
        public int SystemUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
