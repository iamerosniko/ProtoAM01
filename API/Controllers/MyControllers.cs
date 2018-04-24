using API.Entities;

namespace API.Controllers
{
    public class MyControllers
    {
        private readonly AMContext _context;
        public ApplicationsController applicationsController { get; set; }
        public AppRoleServicesController appRoleServicesController { get; set; }
        public AttributesController attributesController { get; set; }
        public InheritedRolesController inheritedRolesController { get; set; }
        public RolesController rolesController { get; set; }
        public ServiceAttributesController serviceAttributesController { get; set; }
        public ServicesController servicesController { get; set; }
        public UserAppRoleServicesController userAppRoleServicesController { get; set; }
        public UserAppsController userAppsController { get; set; }
        public UsersController usersController { get; set; }

        public MyControllers(AMContext context)
        {
            _context = context;
            applicationsController = new ApplicationsController(context);
            appRoleServicesController = new AppRoleServicesController(context);
            attributesController = new AttributesController(context);
            inheritedRolesController = new InheritedRolesController(context);
            rolesController = new RolesController(context);
            serviceAttributesController = new ServiceAttributesController(context);
            servicesController = new ServicesController(context);
            userAppRoleServicesController = new UserAppRoleServicesController(context);
            userAppsController = new UserAppsController(context);
            usersController = new UsersController(context);
        }
    }
}
