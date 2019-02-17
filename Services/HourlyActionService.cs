using System;
using System.Threading;
using Bridgeway.Developer.Test.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bridgeway.Developer.Test.Services {
    public class HourlyActionService : IHourlyActionService {
        private readonly IExampleService _exampleService;
        private readonly ILogger _logger;

        private Timer _timer;

        public HourlyActionService(ILogger<HourlyActionService> logger, IExampleService exampleService) {
            _logger = logger;
            _exampleService = exampleService;
        }

        public void Start() {
            _logger.LogInformation("HourlyActionService Started {0}", DateTime.Now);
            //_timer = new Timer(PerformAction, null, TimeSpan.Zero, TimeSpan.FromHours(1)); // For real
            _timer = new Timer(PerformAction, null, TimeSpan.Zero, TimeSpan.FromSeconds(5)); // For test
        }

        private void PerformAction(object state) {
            // This will get called once an hour.
            // Something should go here that will check the time of day and perform an action if we want it to.
            // We want to be be able to run new code on certain days at a certain hour.
            // For example, on Mondays and Wednesdays, any time between 1400 and 1500.
            // The way we implement this needs to be extendable, as in, we can easily add new actions as needed.
            // It should be object oriented and follow the rule of being open-closed. Open for extension but closed for change.
            // We might want to call these things: ScheduledActions.
            _exampleService.WriteLineToLog();
        }

        public void Dispose() {
            System.Console.WriteLine("HourlyActionService Disposed");
            _timer?.Dispose();
        }

    }
}