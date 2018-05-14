using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers.FrontEnd
{
    [Produces("application/json")]
    [Route("api/FEApplications")]
    public class FEApplicationsController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet]
        public async Task<List<AM_Application>> Get()
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            var apps = await _bTAMProviders.applicationProviders.get();
            return apps;
        }

        [HttpGet("{id}")]
        public async Task<AM_Application> Get(string id)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var app = await _bTAMProviders.applicationProviders.get(id);
            return app;
        }

        [HttpPost]
        public async Task<AM_Application> Post([FromBody]AM_Application value)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var app = await _bTAMProviders.applicationProviders.Post(value);

            return app;
        }

        [HttpPut("{id}")]
        public async Task<AM_Application> Put(string id, [FromBody]AM_Application value)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var app = await _bTAMProviders.applicationProviders.Put(id, value);

            return app;
        }

        [HttpDelete("{id}")]
        public async Task<AM_Application> Delete(string id)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            var a = await Cascade(Convert.ToInt32(id));
            return await _bTAMProviders.applicationProviders.Delete(id);
        }

        //Extensions
        public async Task<bool> Cascade(int applicationID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            try
            {
                //for deletion of users
                var userapps = (await _bTAMProviders.userAppProviders.get()).Where(x => x.AppID == applicationID).ToList();
                //for deletion of roles
                var approleservices = (await _bTAMProviders.appRoleServiceProviders.get()).Where(x => x.AppID == applicationID).ToList();

                foreach (var userapp in userapps)
                {
                    //users
                    await _bTAMProviders.userProviders.Delete(userapp.UserID.ToString());
                    //userapps
                    await _bTAMProviders.userAppProviders.Delete(userapp.UserAppID.ToString());
                }

                foreach (var approleservice in approleservices)
                {
                    //var serviceattributes = (await _bTAMProviders.serviceAttributeProviders.get()).Where(x => x.ServiceID == approleservice.ServiceID).ToList();

                    var userapproleservices = (await _bTAMProviders.userAppRoleServiceProviders.get()).Where(x => x.RoleID == approleservice.RoleID);

                    var inheritedroles = (await _bTAMProviders.inheritedRolesProviders.get()).Where(x => x.RoleID == approleservice.RoleID);
                    //roles
                    await _bTAMProviders.roleProviders.Delete(approleservice.RoleID.ToString());
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
    }
}