using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Roles")]
    public class RolesController : Controller
    {
        private RoleProviders _appSvc;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _appSvc = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            var roles = await _appSvc.get();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _appSvc = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            var role = await _appSvc.get(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<AM_Role> Post([FromBody]AM_Role value)
        {
            _appSvc = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));

            var role = await _appSvc.Post(value);

            return role;
        }

        [HttpPut("{id}")]
        public async Task<AM_Role> Put(string id, [FromBody]AM_Role value)
        {
            _appSvc = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));

            var role = await _appSvc.Put(id, value);

            return role;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _appSvc = new RoleProviders(HttpContext.Session.GetString("authorizationToken"));
            await _appSvc.Delete(id);
        }
    }
}