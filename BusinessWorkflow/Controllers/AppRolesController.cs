using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/AppRoles")]
    public class AppRolesController : Controller
    {
        private AppRoleProviders _appRoleProvider;

        [HttpGet]
        public async Task<List<AM_AppRole>> Get()
        {
            _appRoleProvider = new AppRoleProviders(HttpContext.Session.GetString("authorizationToken"));
            var appRoles = await _appRoleProvider.get();
            return appRoles;
        }

        [HttpGet("{id}")]
        public async Task<AM_AppRole> Get(string id)
        {
            _appRoleProvider = new AppRoleProviders(HttpContext.Session.GetString("authorizationToken"));
            var appRole = await _appRoleProvider.get(id);
            return appRole;
        }

        [HttpPost]
        public async Task<AM_AppRole> Post([FromBody]AM_AppRole value)
        {
            _appRoleProvider = new AppRoleProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _appRoleProvider.Post(value);

            return result;
        }

        //[HttpPut("{id}")]
        //public async Task<AM_AppRole> Put(string id, [FromBody]AM_AppRole value)
        //{
        //    _appRoleProvider = new AppRoleProviders(HttpContext.Session.GetString("authorizationToken"));

        //    var result = await _appRoleProvider.Put(id, value);

        //    return result;
        //}

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _appRoleProvider = new AppRoleProviders(HttpContext.Session.GetString("authorizationToken"));
            await _appRoleProvider.Delete(id);
        }
    }
}