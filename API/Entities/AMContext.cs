using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    public class AMContext : DbContext
    {
        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<AM_Application> Applications { get; set; }
        public DbSet<AM_Role> Roles { get; set; }
        public DbSet<AM_Service> Services { get; set; }
        public DbSet<AM_User> Users { get; set; }
        public DbSet<AM_UserApp> UserApps { get; set; }

        public DbSet<AM_UserAppRoleService> UserAppRoles { get; set; }
        public DbSet<AM_ServiceAttribute> ServiceAttribute { get; set; }
        public DbSet<AM_AppRoleService> AppRoleServices { get; set; }
        public DbSet<AM_InheritedRole> InheritedRoles { get; set; }

        public DbSet<AM_RoleServices> RoleServices { get; set; }
        //decommission
        //public DbSet<AM_AppRole> AppRoles { get; set; }
        //public DbSet<AM_UserAppService> UserAppServices { get; set; }
    }
}
