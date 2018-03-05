using BusinessWorkflow.Utility;
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
            var result = _api.Get().Result;
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);// new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
    }
}
