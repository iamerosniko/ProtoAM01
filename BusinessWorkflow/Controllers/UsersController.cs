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
        public string Post([FromBody]string value)
        {
            return "value";
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]string value)
        {
            return "value";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "value";
        }

        private void bindApiServices()
        {
            _api = new ApiServices("Users", HttpContext.Session.GetString("authorizationToken"));
        }
    }
}
