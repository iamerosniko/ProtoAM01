using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/AppRoleServices")]
    public class AppRoleServicesController : Controller
    {
        private AppRoleServiceProviders _providers;

        [HttpGet]
        public async Task<List<AM_AppRoleService>> Get()
        {
            _providers = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var appRoleServices = await _providers.get();
            return appRoleServices;
        }

        [HttpGet("{id}")]
        public async Task<AM_AppRoleService> Get(string id)
        {
            _providers = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var appRoleService = await _providers.get(id);
            return appRoleService;
        }

        [HttpPost]
        public async Task<AM_AppRoleService> Post([FromBody]AM_AppRoleService value)
        {
            _providers = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _providers.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_AppRoleService> Put(string id, [FromBody]AM_AppRoleService value)
        {
            _providers = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _providers.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _providers = new AppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            await _providers.Delete(id);
        }
    }
}