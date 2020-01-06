using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            var settings = context.Parameters.Get<CookieFeatureFilterSettings>();
            if (_httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(settings.CookieName, out var value))
            {
                return Task.FromResult(value == settings.CookieValue);
            }
            return Task.FromResult(false);
        }
    }

    public class CookieFeatureFilterSettings
    {
        public string CookieName { get; set; }

        public string CookieValue { get; set; }
    }
}