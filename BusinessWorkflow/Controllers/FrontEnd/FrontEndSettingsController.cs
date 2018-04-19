using BusinessWorkflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessWorkflow.Controllers.FrontEnd
{
    [Produces("application/json")]
    [Route("api/FrontEndSettings")]
    public class FrontEndSettingsController : Controller
    {
        [HttpPost]
        public void AssignApiToken([FromBody]AppToken appToken)
        {
            var apiToken = HttpContext.Session.GetString("authorizationToken");
            if (apiToken == null)
            {
                //assign authorizationToken
                HttpContext.Session.SetString("authorizationToken", appToken.Token);
            }
        }
    }
}