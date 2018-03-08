using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/UserApps")]
    public class UserAppsController : Controller
    {
        private UserAppProviders _userAppProvider;

        [HttpGet]
        public async Task<List<AM_UserApp>> Get()
        {
            _userAppProvider = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));
            var userApps = await _userAppProvider.get();
            return userApps;
        }

        [HttpGet("{id}")]
        public async Task<AM_UserApp> Get(string id)
        {
            _userAppProvider = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));
            var userApp = await _userAppProvider.get(id);
            return userApp;
        }

        [HttpPost]
        public async Task<AM_UserApp> Post([FromBody]AM_UserApp value)
        {
            _userAppProvider = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userAppProvider.Post(value);
            return result;
        }

        //[HttpPut("{id}")]
        //public async Task<AM_UserApp> Put(string id, [FromBody]AM_UserApp value)
        //{
        //    _userAppProvider = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));

        //    var result = await _userAppProvider.Put(id, value);

        //    return result;
        //}

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _userAppProvider = new UserAppProviders(HttpContext.Session.GetString("authorizationToken"));
            await _userAppProvider.Delete(id);
        }
    }
}