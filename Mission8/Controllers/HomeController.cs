using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission8.Models;

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
