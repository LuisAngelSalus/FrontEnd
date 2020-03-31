using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE
{
    public class SessionModel
    {
        public SessionModel()
        {
            Companies = new List<Companies>();
        }
        public int SystemUserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int? CustomerCompanyId { get; set; }
        public string Role { get; set; }
        public List<Companies> Companies { get; set; }

    }
    public class Companies
    {
        public Companies()
        {
            Roles = new List<Roles>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<Roles> Roles { get; set; }
    }

    public class Roles
    {
        public Roles()
        {
            Modules = new List<Module>();
        }

        public int RolId { get; set; }
        public string RolName { get; set; }
        public string PathDashboard { get; set; }
        public List<Module> Modules { get; set; }
    }

    public class Module
    {
        public Module()
        {
            Options = new List<Option>();
        }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public string Path { get; set; }
    }
}