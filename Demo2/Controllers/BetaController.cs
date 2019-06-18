using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace Demo2.Controllers
{
  [Feature("BetaUser")]
  public class BetaController : Controller
  {
    //[Feature("BetaUser")]
    public IActionResult Index()
    {
      return Content("This is extra beta user stuff!");
    }
  }
}
