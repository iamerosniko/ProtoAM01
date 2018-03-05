using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Entities
{
    public class AMContext : DbContext
    {
        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<AM_Application> Applications { get; set; }
        public DbSet<AM_AppRole> AppRoles { get; set; }
        public DbSet<AM_Attribute> Attributes { get; set; }
        public DbSet<AM_Role> Roles { get; set; }
        public DbSet<AM_Service> Services { get; set; }
        public DbSet<AM_User> Users { get; set; }
        public DbSet<AM_UserApp> UserApps { get; set; }
        public DbSet<AM_UserAppService> UserAppServices { get; set; }
        public DbSet<API.Entities.AM_ServiceAttribute> AM_ServiceAttribute { get; set; }
    }
}
