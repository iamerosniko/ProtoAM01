using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Models.DTOs
{
    public class MyInheritedRoles
    {
        //for displaying only
        public int InheritedRolesID { get; set; }
        public int MainRoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
        public bool IsEnabled { get; set; }
        public List<Treeview> Trees { get; set; }
    }
}
