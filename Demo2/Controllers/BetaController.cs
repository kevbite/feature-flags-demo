using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace Demo2.Controllers
{
    [FeatureGate("BetaUser")]
    public class BetaController : Controller
    {
        [FeatureGate("BetaUser")]
        public IActionResult Index()
        {
            return Content("This is extra beta user stuff!");
        }
    }
}
