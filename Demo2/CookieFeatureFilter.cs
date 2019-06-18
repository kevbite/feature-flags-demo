using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace Demo2
{
  [FilterAlias("CookieFeatureFilter")]
  public class CookieFeatureFilter : IFeatureFilter
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CookieFeatureFilter(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public bool Evaluate(FeatureFilterEvaluationContext context)
    {
      var settings = context.Parameters.Get<CookieFeatureFilterSettings>();
      if (_httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(settings.CookieName, out var value))
      {
        return value == settings.CookieValue;
      }
      return false;
    }
  }

  public class CookieFeatureFilterSettings
  {
    public string CookieName { get; set; }

    public string CookieValue { get; set; }
  }
}