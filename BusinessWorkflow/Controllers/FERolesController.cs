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
        private AttributeProviders _attributeProviders;
        private ServiceAttributeProviders _serviceAttributeProviders;

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
        public async Task<List<AM_AppRoleService>> ToAppRoleService([FromRoute]int applicationID, [FromBody] AppRoleServicesDTO role)
        {
            /* SEQUENCE
                0) Role
                1) Service
                2) Attribute
                3) Loop then add ids of Attribute and Services to ServiceAttributes
                4) add ids of Application, Role and service to AppRoleServiceID
                5) loop 1 - 4 until list of service is empty
             */
            _attributeProviders = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            _appRoleServiceProviders = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            _serviceAttributeProviders = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            _serviceProviders = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            //dummy
            List<AM_AppRoleService> tempAppRoleServices = new List<AM_AppRoleService>();

            var tempRole = role.Role;
            tempRole = await _roleProviders.Post(tempRole);


            foreach (var service in role.Services)
            {
                var tempService = new AM_Service
                {
                    ServiceDesc = service.ServiceDesc,
                    ServiceName = service.ServiceName
                };

                tempService = await _serviceProviders.Post(tempService);

                foreach (var attribute in service.Attributes)
                {
                    var tempAttribute = attribute;
                    tempAttribute = await _attributeProviders.Post(tempAttribute);

                    var tempServiceAttribute = await _serviceAttributeProviders.Post(
                            new AM_ServiceAttribute
                            {
                                AttribID = tempAttribute.AttribID,
                                ServiceID = tempService.ServiceID
                            }
                        );
                }

                var tempAppRoleService = new AM_AppRoleService
                {
                    AppID = applicationID,
                    RoleID = tempRole.RoleID,
                    ServiceID = tempService.ServiceID
                };

                tempAppRoleService = await _appRoleServiceProviders.Post(tempAppRoleService);
                tempAppRoleServices.Add(tempAppRoleService);
            }


            return tempAppRoleServices;
        }
    }
}