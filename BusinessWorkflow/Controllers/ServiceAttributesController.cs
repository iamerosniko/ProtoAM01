using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/ServiceAttributes")]
    public class ServiceAttributesController : Controller
    {
        private ServiceAttributeProviders _serviceAttributeProvider;

        [HttpGet]
        public async Task<List<AM_ServiceAttribute>> Get()
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var serviceAttributes = await _serviceAttributeProvider.get();
            return serviceAttributes;
        }

        [HttpGet("{id}")]
        public async Task<AM_ServiceAttribute> Get(string id)
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var serviceAttribute = await _serviceAttributeProvider.get(id);
            return serviceAttribute;
        }

        [HttpPost]
        public async Task<AM_ServiceAttribute> Post([FromBody]AM_ServiceAttribute value)
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _serviceAttributeProvider.Post(value);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_ServiceAttribute> Put(string id, [FromBody]AM_ServiceAttribute value)
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _serviceAttributeProvider.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            await _serviceAttributeProvider.Delete(id);
        }
    }
}