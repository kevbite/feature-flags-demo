using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

namespace Demo1
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var serviceCollection = new ServiceCollection();
      serviceCollection.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true).Build());

      serviceCollection.AddSingleton<App>();

      serviceCollection.AddFeatureManagement()
            .AddFeatureFilter<TimeWindowFilter>()
            .AddFeatureFilter<PercentageFilter>()
            ;

      var serviceProvider = serviceCollection.BuildServiceProvider();

      using (var scope = serviceProvider.CreateScope())
      {
        var app = scope.ServiceProvider.GetService<App>();
        await app.Execute();
      }

    }
  }
}

