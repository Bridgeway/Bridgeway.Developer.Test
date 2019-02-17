using System;
using System.Threading;
using System.Threading.Tasks;
using Bridgeway.Developer.Test.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway.Developer.Test {
    class Program {
        private static readonly AutoResetEvent _waitHandle = new AutoResetEvent(false);

        static void Main(string[] args) {

            Console.WriteLine("Console App Starting");
            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var hourlyActionService = serviceProvider.GetService<IHourlyActionService>();
            hourlyActionService.Start();

            

            RequireCONTROLCToStopApp();
        }

        private static void RequireCONTROLCToStopApp() {
            Console.CancelKeyPress += (o, e) => {
                Console.WriteLine("Console App Exited");
                _waitHandle.Set();
            };

            _waitHandle.WaitOne();
        }
    }
}