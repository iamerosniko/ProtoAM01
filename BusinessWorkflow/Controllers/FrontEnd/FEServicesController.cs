using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/FEServices")]
    public class FEServicesController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet("{roleID}")]
        public async Task<List<AM_Service>> Get([FromRoute]int roleID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            List<AM_Service> services = new List<AM_Service>();
            List<AM_RoleService> roleServices = await _bTAMProviders.roleServiceProviders.get();

            foreach (var roleService in roleServices.Where(x => x.RoleID == roleID))
            {
                var service = await _bTAMProviders.serviceProviders.get(roleService.ServiceID.ToString());
                if (service != null)
                {
                    services.Add(service);
                }
            }

            return services;
        }


        [HttpPost("{roleID}")]
        public async Task<AM_RoleService> Post([FromRoute]int roleID, [FromBody] AM_Service service)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            if (roleID != 0 && service != null)
            {
                AM_Service newService = await _bTAMProviders.serviceProviders.Post(service);
                AM_RoleService roleService = new AM_RoleService
                {
                    RoleID = roleID,
                    ServiceID = newService.ServiceID
                };

                return await _bTAMProviders.roleServiceProviders.Post(roleService);
            }

            return null;
        }

        [HttpPut]
        public async Task<AM_Service> Put([FromBody] AM_Service service)
        {
            if (service != null)
            {
                return await _bTAMProviders.serviceProviders.Put(service.ServiceID.ToString(), service);
            }
            return null;
        }

        [HttpDelete("{serviceID}")]
        public async Task<AM_Service> Delete([FromRoute]int serviceID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            List<AM_RoleService> roleServices = (await _bTAMProviders.roleServiceProviders.get()).Where(x => x.ServiceID == serviceID).ToList();

            foreach (var roleService in roleServices)
            {
                await _bTAMProviders.roleServiceProviders.Delete(roleService.RoleServiceID.ToString());
            }

            return await _bTAMProviders.serviceProviders.Delete(serviceID.ToString());
        }
    }
}