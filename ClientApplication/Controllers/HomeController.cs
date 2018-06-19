using ClientApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.Name == "" || HttpContext.User.Identity.Name == null)
            {
                return Redirect("~/Auth/SignIn");
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
