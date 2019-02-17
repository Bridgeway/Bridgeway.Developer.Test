using Bridgeway.Developer.Test.Services;
using Bridgeway.Developer.Test.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bridgeway.Developer.Test {
    public class Startup {
        IConfigurationRoot Configuration { get; }

        public Startup() {
            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddLogging(loggingBuilder => 
                loggingBuilder.AddConsole()
            );

            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddTransient<IExampleService, ExampleService>();
            services.AddTransient<IHourlyActionService, HourlyActionService>();

            // New services go under here.

        }

    }
}