using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace Demo2.Controllers
{
    [FeatureGate("MemberUser")]
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return Content("You have the member cookie!");
        }
    }
}
