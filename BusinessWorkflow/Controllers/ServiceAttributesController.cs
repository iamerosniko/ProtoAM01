using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/ServiceAttributes")]
    public class ServiceAttributesController : Controller
    {
        private ServiceAttributeProviders _serviceAttributeProvider;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var users = await _serviceAttributeProvider.get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _serviceAttributeProvider = new ServiceAttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var user = await _serviceAttributeProvider.get(id);
            return Ok(user);
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