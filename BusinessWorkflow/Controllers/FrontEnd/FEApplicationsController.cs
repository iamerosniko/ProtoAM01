using BusinessWorkflow.Models;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers.FrontEnd
{
    [Produces("application/json")]
    [Route("api/FEApplications")]
    public class FEApplicationsController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet]
        public async Task<List<AM_Application>> Get()
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            var apps = await _bTAMProviders.applicationProviders.get();
            return apps;
        }

        [HttpGet("{id}")]
        public async Task<AM_Application> Get(string id)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var app = await _bTAMProviders.applicationProviders.get(id);
            return app;
        }

        [HttpPost]
        public async Task<AM_Application> Post([FromBody]AM_Application value)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var app = await _bTAMProviders.applicationProviders.Post(value);

            return app;
        }

        [HttpPut("{id}")]
        public async Task<AM_Application> Put(string id, [FromBody]AM_Application value)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            var app = await _bTAMProviders.applicationProviders.Put(id, value);

            return app;
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            await _bTAMProviders.applicationProviders.Delete(id);
        }
    }
}