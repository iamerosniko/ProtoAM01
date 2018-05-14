using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/FERoles")]
    public class FERolesController : Controller
    {
        private BTAMProviders _bTAMProviders;

        //getting list of roles for selected application
        [HttpGet("{appID}")]
        public async Task<List<AM_Role>> Get(int appID)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            List<AM_Role> roles = new List<AM_Role>();

            var userAppServices = await _bTAMProviders.appRoleServiceProviders.get();
            userAppServices = userAppServices.Where(x => x.AppID == appID).ToList();

            foreach (AM_AppRoleService appRoleService in userAppServices)
            {
                var tempRole = await _bTAMProviders.roleProviders.get(appRoleService.RoleID.ToString());
                if (tempRole != null)
                {
                    roles.Add(tempRole);
                }
            }

            //return all roles in selected application
            return roles;
        }

        [HttpPost("{applicationID}")]
        public async Task<AM_AppRoleService> Post([FromRoute]int applicationID, [FromBody]AM_Role role)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempRole = await _bTAMProviders.roleProviders.Post(role);
            AM_AppRoleService appRoleService = new AM_AppRoleService
            {
                AppID = applicationID,
                RoleID = tempRole.RoleID
            };
            return await _bTAMProviders.appRoleServiceProviders.Post(appRoleService);
        }

        [HttpPut("{roleID}")]
        public async Task<AM_Role> Put([FromRoute] string roleID, [FromBody]AM_Role role)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            var tempRole = await _bTAMProviders.roleProviders.Put(role.RoleID.ToString(), role);
            return tempRole;
        }

        [HttpDelete("{roleID}")]
        public async Task<AM_Role> Delete([FromRoute]string roleID)
        {
            //instantiate
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var tempRole = await _bTAMProviders.roleProviders.Delete(roleID);
            var a = await Cascade(Convert.ToInt32(roleID));

            return tempRole;
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
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            //dummy
            List<AM_AppRoleService> tempAppRoleServices = new List<AM_AppRoleService>();

            var tempRole = role.Role;
            tempRole = await _bTAMProviders.roleProviders.Post(tempRole);


            foreach (var service in role.Services)
            {
                var tempService = new AM_Service
                {
                    ServiceDesc = service.ServiceDesc,
                    ServiceName = service.ServiceName
                };

                tempService = await _bTAMProviders.serviceProviders.Post(tempService);

                foreach (var attribute in service.Attributes)
                {
                    var tempAttribute = attribute;
                    tempAttribute = await _bTAMProviders.attributeProviders.Post(tempAttribute);

                    var tempServiceAttribute = await _bTAMProviders.serviceAttributeProviders.Post(
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
                };

                tempAppRoleService = await _bTAMProviders.appRoleServiceProviders.Post(tempAppRoleService);
                tempAppRoleServices.Add(tempAppRoleService);
            }

            return tempAppRoleServices;
        }

        public async Task<bool> Cascade(int roleID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            try
            {
                //for deletion of roles
                var approleservices = (await _bTAMProviders.appRoleServiceProviders.get()).Where(x => x.RoleID == roleID).ToList();

                foreach (var approleservice in approleservices)
                {
                    //var serviceattributes = (await _bTAMProviders.serviceAttributeProviders.get()).Where(x => x.ServiceID == approleservice.ServiceID).ToList();

                    var userapproleservices = (await _bTAMProviders.userAppRoleServiceProviders.get()).Where(x => x.RoleID == approleservice.RoleID);

                    var inheritedroles = (await _bTAMProviders.inheritedRolesProviders.get()).Where(x => x.RoleID == approleservice.RoleID);
                    //approleservices
                    await _bTAMProviders.appRoleServiceProviders.Delete(approleservice.AppRoleServiceID.ToString());

                    //foreach (var serviceattribute in serviceattributes)
                    //{
                    //    //serviceattributes
                    //    await _bTAMProviders.serviceAttributeProviders.Delete(serviceattribute.ServiceAttributeID.ToString());
                    //    //attributes
                    //    await _bTAMProviders.attributeProviders.Delete(serviceattribute.AttribID.ToString());
                    //    //services
                    //    await _bTAMProviders.serviceProviders.Delete(approleservice.ServiceID.ToString());
                    //}

                    foreach (var userapproleservice in userapproleservices)
                    {
                        //userapproleservices
                        await _bTAMProviders.userAppRoleServiceProviders.Delete(userapproleservice.UserAppRoleServiceID.ToString());
                    }

                    foreach (var inheritedrole in inheritedroles)
                    {
                        //inheritedroles
                        await _bTAMProviders.inheritedRolesProviders.Delete(inheritedrole.InheritedRolesID.ToString());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //services
        public async Task<bool> Cascade2(int serviceID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            try
            {
                //for deletion of roles

                var serviceattributes = (await _bTAMProviders.serviceAttributeProviders.get()).Where(x => x.ServiceID == serviceID).ToList();


                foreach (var serviceattribute in serviceattributes)
                {
                    //serviceattributes
                    await _bTAMProviders.serviceAttributeProviders.Delete(serviceattribute.ServiceAttributeID.ToString());
                    //attributes
                    await _bTAMProviders.attributeProviders.Delete(serviceattribute.AttribID.ToString());
                }


                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Cascade3(int attrubuteID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            try
            {
                //for deletion of roles

                var serviceattributes = (await _bTAMProviders.serviceAttributeProviders.get()).Where(x => x.AttribID == attrubuteID).ToList();


                foreach (var serviceattribute in serviceattributes)
                {
                    //serviceattributes
                    await _bTAMProviders.serviceAttributeProviders.Delete(serviceattribute.ServiceAttributeID.ToString());
                    //attributes
                    await _bTAMProviders.serviceProviders.Delete(serviceattribute.ServiceID.ToString());
                }


                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}