﻿using System;
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

    public class GetSystemUserDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class SystemUserRegisterDto
    {
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
