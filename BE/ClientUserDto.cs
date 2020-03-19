using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClientUserDto
    {
        public int ClientUserId { get; set; }
        public int CompanyId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int UserTypeId { get; set; }
        public int TypeDocumentId { get; set; }
        public string NroDocument { get; set; }
        public string NroCpm { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
    }

    public class ClientUserRegisterDto
    {
        public int CompanyId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public int TypeDocumentId { get; set; }
        public string NroDocument { get; set; }
        public string NroCpm { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public int InsertUserId { get; set; }      
        
    }

    public class ClientUserUpdateDto
    {
        public int ClientUserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int UserTypeId { get; set; }
        public int TypeDocumentId { get; set; }
        public string NroDocument { get; set; }
        public string NroCpm { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public int UpdateUserId { get; set; }
    }

    public class ClientUserPasswordDto
    {
        public int ClientUserId { get; set; }
        public string Password { get; set; }
        public int UpdateUserId { get; set; }
    }
}
