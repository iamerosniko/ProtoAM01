using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/UserAppRoleServices")]
    public class UserAppRoleServicesController : Controller
    {
        private UserAppRoleServiceProviders _providers;

        [HttpGet]
        public async Task<List<AM_UserAppRoleService>> Get()
        {
            _providers = new UserAppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var userAppRoleServices = await _providers.get();
            return userAppRoleServices;
        }

        [HttpGet("{id}")]
        public async Task<AM_UserAppRoleService> Get(string id)
        {
            _providers = new UserAppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var userAppRoleService = await _providers.get(id);
            return userAppRoleService;
        }

        [HttpPost]
        public async Task<AM_UserAppRoleService> Post([FromBody]AM_UserAppRoleService value)
        {
            _providers = new UserAppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _providers.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_UserAppRoleService> Put(string id, [FromBody]AM_UserAppRoleService value)
        {
            _providers = new UserAppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _providers.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _providers = new UserAppRoleServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            await _providers.Delete(id);
        }
    }
}