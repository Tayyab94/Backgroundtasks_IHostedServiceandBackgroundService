using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backgroundtasks_IHostedServiceandBackgroundService
{
    public class BackgroundPrinter : IHostedService,IDisposable
    {
        private readonly ILogger<BackgroundPrinter> logger;


        private int number = 0;
        private Timer timer;


        public BackgroundPrinter(ILogger<BackgroundPrinter>logger)
        {
            this.logger = logger;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(s =>
            {
                Interlocked.Increment(ref number);
                logger.LogInformation($"Printing form the workers ={number}");
            },
                null, TimeSpan.Zero, TimeSpan.FromSeconds(6));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Printing Worker stopping");
            return Task.CompletedTask;
        }
    }
}
