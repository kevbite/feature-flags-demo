using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace Demo2.Controllers
{
  [Feature("Cookie")]
  public class CookieController : Controller
  {
    public IActionResult Index()
    {
      return Content("You have the correct cookie!");
    }
  }
}
