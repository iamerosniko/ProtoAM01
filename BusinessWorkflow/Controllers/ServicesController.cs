using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        private ServiceProviders _ServiceProvider;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _ServiceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var users = await _ServiceProvider.get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _ServiceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            var user = await _ServiceProvider.get(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<AM_Service> Post([FromBody]AM_Service value)
        {
            _ServiceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _ServiceProvider.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_Service> Put(string id, [FromBody]AM_Service value)
        {
            _ServiceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _ServiceProvider.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _ServiceProvider = new ServiceProviders(HttpContext.Session.GetString("authorizationToken"));
            await _ServiceProvider.Delete(id);
        }
    }
}