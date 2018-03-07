using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using BusinessWorkflow.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private ApiServices _api;
        private UserServices _userSvc;

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _userSvc = new UserServices(HttpContext.Session.GetString("authorizationToken"));
            var users = await _userSvc.get();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _userSvc = new UserServices(HttpContext.Session.GetString("authorizationToken"));
            var user = await _userSvc.get(id);
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<AM_User> Post([FromBody]AM_User user)
        {
            _userSvc = new UserServices(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userSvc.Post(user);

            return result;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<AM_User> Put(string id, [FromBody]AM_User user)
        {
            _userSvc = new UserServices(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userSvc.Put(id, user);

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _userSvc = new UserServices(HttpContext.Session.GetString("authorizationToken"));
            await _userSvc.Delete(id);
        }

        private void bindApiServices()
        {
            _api = new ApiServices("Users", HttpContext.Session.GetString("authorizationToken"));
        }
    }
}
