using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkflow.Controllers
{
    [Produces("application/json")]
    [Route("api/Applications")]
    public class ApplicationsController : Controller
    {
        private ApplicationProviders _appProviders;

        //[HttpGet]
        //public async Task<List<AM_Application>> Get()
        //{
        //    _appProviders = new ApplicationProviders(HttpContext.Session.GetString("authorizationToken"));
        //    var apps = await _appProviders.get();
        //    return apps;
        //}

        //[HttpGet("{id}")]
        //public async Task<AM_Application> Get(string id)
        //{
        //    _appProviders = new ApplicationProviders(HttpContext.Session.GetString("authorizationToken"));
        //    var app = await _appProviders.get(id);
        //    return app;
        //}

        //[HttpPost]
        //public async Task<AM_Application> Post([FromBody]AM_Application value)
        //{
        //    _appProviders = new ApplicationProviders(HttpContext.Session.GetString("authorizationToken"));

        //    var app = await _appProviders.Post(value);

        //    return app;
        //}

        //[HttpPut("{id}")]
        //public async Task<AM_Application> Put(string id, [FromBody]AM_Application value)
        //{
        //    _appProviders = new ApplicationProviders(HttpContext.Session.GetString("authorizationToken"));

        //    var app = await _appProviders.Put(id, value);

        //    return app;
        //}

        //[HttpDelete("{id}")]
        //public async void Delete(string id)
        //{
        //    _appProviders = new ApplicationProviders(HttpContext.Session.GetString("authorizationToken"));
        //    await _appProviders.Delete(id);
        //}

    }
}
