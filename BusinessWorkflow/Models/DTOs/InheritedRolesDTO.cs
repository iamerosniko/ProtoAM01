using System.Collections.Generic;

namespace BusinessWorkflow.Models.DTOs
{
    public class InheritedRolesDTO
    {
        public int InheritedRolesID { get; set; }
        //FK AppRoleServices
        public int MainRoleID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
        public bool IsEnabled { get; set; }
        public List<InheritedRolesDTO> InheritedRoles { get; set; }
    }
}
