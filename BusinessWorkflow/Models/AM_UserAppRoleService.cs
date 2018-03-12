namespace BusinessWorkflow.Models
{
    public class AM_UserAppRoleService
    {
        public int UserAppRoleServiceID { get; set; }
        //FK UserApps
        public int UserAppID { get; set; }
        //FK AppRoleServices
        //public int AppRoleServiceID { get; set; }
        public int AppRoleID { get; set; }

    }
}
