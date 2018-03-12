using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/InheritedRoles")]
    public class InheritedRolesController : Controller
    {
        private InheritedRolesProviders _providers;

        [HttpGet]
        public async Task<List<AM_InheritedRole>> Get()
        {
            _providers = new InheritedRolesProviders(HttpContext.Session.GetString("authorizationToken"));
            var inheritedRoles = await _providers.get();
            return inheritedRoles;
        }

        [HttpGet("{id}")]
        public async Task<AM_InheritedRole> Get(string id)
        {
            _providers = new InheritedRolesProviders(HttpContext.Session.GetString("authorizationToken"));
            var inheritedRoles = await _providers.get(id);
            return inheritedRoles;
        }

        [HttpPost]
        public async Task<AM_InheritedRole> Post([FromBody]AM_InheritedRole value)
        {
            _providers = new InheritedRolesProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _providers.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_InheritedRole> Put(string id, [FromBody]AM_InheritedRole value)
        {
            _providers = new InheritedRolesProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _providers.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _providers = new InheritedRolesProviders(HttpContext.Session.GetString("authorizationToken"));
            await _providers.Delete(id);
        }
    }
}