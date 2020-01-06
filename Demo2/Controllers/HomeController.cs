using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Demo2.Models;
using Microsoft.FeatureManagement.Mvc;

namespace Demo2.Controllers
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

        [FeatureGate("BetaUser")]
        public IActionResult Beta()
        {
            return Content($"Beta action on {nameof(HomeController)}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
