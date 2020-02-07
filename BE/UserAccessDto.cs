using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class UserAccessDto
    {
        public int SystemUserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }

        public List<UserAccessCompanies> Companies { get; set; }
    }

    public class UserAccessCompanies
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<UserAccessRoles> Roles { get; set; }
    }

    public class UserAccessRoles
    {
        public int RolId { get; set; }
        public string RolName { get; set; }
        public string PathDashboard { get; set; }
        public List<UserAccessModule> Modules { get; set; }
    }

    public class UserAccessModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public List<UserAccessOption> Options { get; set; }
    }

    public class UserAccessOption
    {
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public string Path { get; set; }
    }
}
