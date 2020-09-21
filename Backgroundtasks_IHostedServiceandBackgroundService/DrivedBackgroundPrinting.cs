using Backgroundtasks_IHostedServiceandBackgroundService.Model;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backgroundtasks_IHostedServiceandBackgroundService
{
    public class DrivedBackgroundPrinting : BackgroundService
    {

        // this is less code.. for implementing the job
        private readonly IWorker worker;

        public DrivedBackgroundPrinting(IWorker worker)
        {
            this.worker = worker;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DoWork(stoppingToken);
        }
    }
}
