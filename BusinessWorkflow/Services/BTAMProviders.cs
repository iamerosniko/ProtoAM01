using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkflow.Services
{
    [Produces("application/json")]
    [Route("api/BTAMProviders")]
    public class BTAMProviders : Controller
    {
        public ApplicationProviders applicationProviders { get; set; }
        public AppRoleServiceProviders appRoleServiceProviders { get; set; }
        public InheritedRolesProviders inheritedRolesProviders { get; set; }
        public RoleProviders roleProviders { get; set; }
        public ServiceAttributeProviders serviceAttributeProviders { get; set; }
        public ServiceProviders serviceProviders { get; set; }
        public UserAppProviders userAppProviders { get; set; }
        public UserAppRoleServiceProviders userAppRoleServiceProviders { get; set; }
        public UserProviders userProviders { get; set; }

        public RoleServiceProviders roleServiceProviders { get; set; }


        public BTAMProviders(string authorizationToken)
        {
            applicationProviders = new ApplicationProviders(authorizationToken);
            appRoleServiceProviders = new AppRoleServiceProviders(authorizationToken);
            inheritedRolesProviders = new InheritedRolesProviders(authorizationToken);
            roleProviders = new RoleProviders(authorizationToken);
            serviceAttributeProviders = new ServiceAttributeProviders(authorizationToken);
            serviceProviders = new ServiceProviders(authorizationToken);
            userAppRoleServiceProviders = new UserAppRoleServiceProviders(authorizationToken);
            userAppProviders = new UserAppProviders(authorizationToken);
            userProviders = new UserProviders(authorizationToken);
            roleServiceProviders = new RoleServiceProviders(authorizationToken);
        }
    }
}