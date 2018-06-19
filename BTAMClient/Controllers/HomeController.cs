using BTAMClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTAMClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            if (HttpContext.User.Identity.Name == "" || HttpContext.User.Identity.Name == null)
            {
                return Redirect("~/App/SignIn");
            }
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
