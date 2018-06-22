using BTAMClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BTAMClient.Controllers
{
    [Produces("application/json")]
    [Route("App")]
    public class AuthController : Controller
    {
        [Route("signin")]
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" });
        }

        [Route("getBW")]
        [HttpPost]
        public URLData getBWURL()
        {
            return new URLData
            {
                URL = Startup.Configuration["AppEnv:BW"]
            };
        }


    }
}