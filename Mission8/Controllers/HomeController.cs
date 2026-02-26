using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
