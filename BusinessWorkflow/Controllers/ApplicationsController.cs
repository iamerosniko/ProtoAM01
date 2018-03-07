using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Applications")]
    public class ApplicationsController : Controller
    {
        private ApplicationServices _appSvc;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _appSvc = new ApplicationServices(HttpContext.Session.GetString("authorizationToken"));
            var apps = await _appSvc.get();
            return Ok(apps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _appSvc = new ApplicationServices(HttpContext.Session.GetString("authorizationToken"));
            var user = await _appSvc.get(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<AM_Application> Post([FromBody]AM_Application value)
        {
            _appSvc = new ApplicationServices(HttpContext.Session.GetString("authorizationToken"));

            var result = await _appSvc.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_Application> Put(string id, [FromBody]AM_Application value)
        {
            _appSvc = new ApplicationServices(HttpContext.Session.GetString("authorizationToken"));

            var result = await _appSvc.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _appSvc = new ApplicationServices(HttpContext.Session.GetString("authorizationToken"));
            await _appSvc.Delete(id);
        }

    }
}
