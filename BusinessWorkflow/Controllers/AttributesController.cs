using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Attributes")]
    public class AttributesController : Controller
    {
        private AttributeProviders _userSvc;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _userSvc = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var users = await _userSvc.get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _userSvc = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            var user = await _userSvc.get(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<AM_Attribute> Post([FromBody]AM_Attribute value)
        {
            _userSvc = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userSvc.Post(value);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<AM_Attribute> Put(string id, [FromBody]AM_Attribute value)
        {
            _userSvc = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));

            var result = await _userSvc.Put(id, value);

            return result;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _userSvc = new AttributeProviders(HttpContext.Session.GetString("authorizationToken"));
            await _userSvc.Delete(id);
        }

    }
}