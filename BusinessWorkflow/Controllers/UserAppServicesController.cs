using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/UserAppServices")]
    public class UserAppServicesController : Controller
    {
        private UserAppServiceProviders _userAppServiceProviders;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _userAppServiceProviders = new UserAppServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var users = await _userAppServiceProviders.get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _userAppServiceProviders = new UserAppServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var user = await _userAppServiceProviders.get(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<AM_UserAppService> Post([FromBody]AM_UserAppService value)
        {
            _userAppServiceProviders = new UserAppServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userAppServiceProviders.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_UserAppService> Put(string id, [FromBody]AM_UserAppService value)
        {
            _userAppServiceProviders = new UserAppServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userAppServiceProviders.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _userAppServiceProviders = new UserAppServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            await _userAppServiceProviders.Delete(id);
        }
    }
}