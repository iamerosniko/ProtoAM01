namespace BusinessWorkflow.Models
{
    public class AM_InheritedRole
    {
        public int InheritedRolesID { get; set; }
        //FK AppRoleServices
        public int MainRoleID { get; set; }

        public int RoleID { get; set; }
    }
}
