using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/FERoles")]
    public class FERolesController : Controller
    {
        private RoleProviders _roleProviders;
        private AppRoleServiceProviders _appRoleServiceProviders;
        private ServiceProviders _serviceProviders;

        [HttpPost("{applicationID}")]
        public async Task<AM_AppRoleService> Post([FromRoute]int applicationID, [FromBody]AM_Role role)
        {
            //instantiate
            _appRoleServiceProviders = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempRole = await _roleProviders.Post(role);
            AM_AppRoleService appRoleService = new AM_AppRoleService
            {
                AppID = applicationID,
                RoleID = tempRole.RoleID
            };
            return await _appRoleServiceProviders.Post(appRoleService);
        }

        //getting list of roles for selected application
        [HttpGet("{appID}")]
        public async Task<List<AM_Role>> Get(int appID)
        {
            //instantiate
            _appRoleServiceProviders = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));

            List<AM_Role> roles = new List<AM_Role>();

            var userAppServices = await _appRoleServiceProviders.get();
            userAppServices = userAppServices.Where(x => x.AppID == appID).ToList();

            foreach (AM_AppRoleService appRoleService in userAppServices)
            {
                var tempRole = await _roleProviders.get(appRoleService.RoleID.ToString());
                if (tempRole != null)
                {
                    roles.Add(tempRole);
                }
            }

            //return all roles in selected application
            return roles;
        }

        //when adding services 
        [HttpPost("ToService/{appRoleServiceID}")]
        public async Task<AM_AppRoleService> ToAppRoleService([FromRoute]int appRoleServiceID, [FromBody] AppRoleServicesDTO roles)
        {
            _appRoleServiceProviders = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            _serviceProviders = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var appRoleServices = await _appRoleServiceProviders.get(appRoleServiceID.ToString());

            //var tempServices = _serviceProviders.Post(service);

            return appRoleServices;
        }
    }
}