using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        private ServiceProviders _serviceProvider;

        [HttpGet]
        public async Task<List<AM_Service>> Get()
        {
            _serviceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var services = await _serviceProvider.get();
            return services;
        }

        [HttpGet("{id}")]
        public async Task<AM_Service> Get(string id)
        {
            _serviceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var service = await _serviceProvider.get(id);
            return service;
        }

        [HttpPost]
        public async Task<AM_Service> Post([FromBody]AM_Service value)
        {
            _serviceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _serviceProvider.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_Service> Put(string id, [FromBody]AM_Service value)
        {
            _serviceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _serviceProvider.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _serviceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            await _serviceProvider.Delete(id);
        }
    }
}