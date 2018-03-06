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

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            bindApiServices();

            var result = await _api.Get();
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            bindApiServices();

            var result = await _api.Get(id);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
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
