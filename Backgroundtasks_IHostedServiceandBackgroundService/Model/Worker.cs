using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backgroundtasks_IHostedServiceandBackgroundService.Model
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;

        private int number = 0;
        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }


        public async Task DoWork(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);

                logger.LogInformation($"Worker Class is Execiting {number} Times");

               // await Task.Delay(1000 * 5);
               await Task.Delay(TimeSpan.FromSeconds(5));

            }
        }
    }
}
