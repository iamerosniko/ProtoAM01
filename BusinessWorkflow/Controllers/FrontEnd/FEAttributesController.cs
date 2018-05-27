using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers.FrontEnd
{
    [Produces("application/json")]
    [Route("api/FEAttributes")]
    public class FEAttributesController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet("{roleServiceID}")]
        public async Task<List<AM_ServiceAttribute>> GetAttributes([FromRoute]int roleServiceID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var allServiceAttributes = await _bTAMProviders.serviceAttributeProviders.get();

            return allServiceAttributes.Where(x => x.RoleServiceID == roleServiceID).ToList();
        }

        [HttpPost]
        public async Task<AM_ServiceAttribute> PostAttribute([FromBody]AM_ServiceAttribute attribute)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            return await _bTAMProviders.serviceAttributeProviders.Post(attribute);
        }

        [HttpPut("{attributeID}")]
        public async Task<AM_ServiceAttribute> PutAttribute([FromRoute]string attributeID, [FromBody]AM_ServiceAttribute attribute)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            return await _bTAMProviders.serviceAttributeProviders.Put(attributeID, attribute);
        }


        [HttpDelete("{attributeID}")]
        public async Task<AM_ServiceAttribute> DeleteAttribute([FromRoute]string attributeID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            return await _bTAMProviders.serviceAttributeProviders.Delete(attributeID);
        }
    }
}