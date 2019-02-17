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
            _exampleService.WriteLineToLog();
        }

        public void Dispose() {
            _logger.LogInformation("HourlyActionService Disposed {0}", DateTime.Now);
            _timer?.Dispose();
        }

    }
}