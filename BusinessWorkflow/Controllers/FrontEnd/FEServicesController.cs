using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [EnableCors("CORS")]

    [Produces("application/json")]
    [Route("api/FEServices")]
    public class FEServicesController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet("{roleID}")]
        public async Task<List<AM_RoleService>> Get([FromRoute]int roleID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            List<AM_RoleService> roleServices = await _bTAMProviders.roleServiceProviders.get();

            return roleServices.Where(x => x.RoleID == roleID).ToList();
        }

        [HttpPost]
        public async Task<AM_RoleService> Post([FromBody] AM_RoleService roleservice)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            if (roleservice != null)
            {
                return await _bTAMProviders.roleServiceProviders.Post(roleservice);
            }

            return null;
        }

        [HttpPut("{roleserviceID}")]
        public async Task<AM_RoleService> Put([FromRoute]string roleserviceID, [FromBody] AM_RoleService roleservice)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            if (roleservice != null)
            {
                return await _bTAMProviders.roleServiceProviders.Put(roleserviceID.ToString(), roleservice);

            }

            return null;
        }

        [HttpDelete("{roleServiceID}")]
        public async Task<AM_RoleService> Delete([FromRoute]int roleServiceID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            return await _bTAMProviders.roleServiceProviders.Delete(roleServiceID.ToString());
        }
    }
}