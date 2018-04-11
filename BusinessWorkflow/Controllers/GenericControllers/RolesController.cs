using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Roles")]
    public class RolesController : Controller
    {
        private RoleProviders _roleProviders;

        [HttpGet]
        public async Task<List<AM_Role>> Get()
        {
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            var roles = await _roleProviders.get();
            return roles;
        }

        [HttpGet("{id}")]
        public async Task<AM_Role> Get(string id)
        {
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            var role = await _roleProviders.get(id);
            return role;
        }

        [HttpPost]
        public async Task<AM_Role> Post([FromBody]AM_Role value)
        {
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));

            var role = await _roleProviders.Post(value);
            return role;
        }

        [HttpPut("{id}")]
        public async Task<AM_Role> Put(string id, [FromBody]AM_Role value)
        {
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));

            var role = await _roleProviders.Put(id, value);

            return role;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _roleProviders = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            await _roleProviders.Delete(id);
        }
    }
}