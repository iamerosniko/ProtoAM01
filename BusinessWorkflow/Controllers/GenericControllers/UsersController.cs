using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private UserProviders _userProviders;

        [HttpGet]
        public async Task<List<AM_User>> Get()
        {
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));
            var users = await _userProviders.get();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<AM_User> Get(string id)
        {
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));
            var user = await _userProviders.get(id);
            return user;
        }

        [HttpPost]
        public async Task<AM_User> Post([FromBody]AM_User value)
        {
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userProviders.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_User> Put(string id, [FromBody]AM_User value)
        {
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userProviders.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _userProviders = new UserProviders(HttpContext.Session.GetString("authorizationToken"));
            await _userProviders.Delete(id);
        }

    }
}
