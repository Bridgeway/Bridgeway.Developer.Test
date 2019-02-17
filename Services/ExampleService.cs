using System;
using Bridgeway.Developer.Test.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bridgeway.Developer.Test.Services {
    public class ExampleService : IExampleService {

        ILogger _logger;

        public ExampleService(ILogger<ExampleService> logger) {
            _logger = logger;
        }

        public void WriteLineToLog() => 
            _logger.LogInformation("Example line logged {0}", DateTime.Now);

    }
}