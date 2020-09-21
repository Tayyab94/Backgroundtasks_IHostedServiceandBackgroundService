using Backgroundtasks_IHostedServiceandBackgroundService.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backgroundtasks_IHostedServiceandBackgroundService
{

    // We can Inherit BackgrounSsevice.. to run the backgroun servicess. and that code is too much less than this
    public class BackgroundPrinter_with_dependency : IHostedService
    {
        private readonly ILogger<BackgroundPrinter_with_dependency> logger;
        private readonly IWorker worker;

        public BackgroundPrinter_with_dependency(ILogger<BackgroundPrinter_with_dependency> logger,IWorker worker)
        {
            this.logger = logger;
            this.worker = worker;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //timer = new Timer(s =>
            //{
            //    Interlocked.Increment(ref number);
            //    logger.LogInformation($"Printing form the workers ={number}");
            //},
            //    null, TimeSpan.Zero, TimeSpan.FromSeconds(6));

            //return Task.CompletedTask;


            /// ass asyns
            /// 
            await worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Printing Worker stopping");
            return Task.CompletedTask;
        }
    }
}
