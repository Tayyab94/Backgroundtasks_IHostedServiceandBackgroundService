using System.Threading;
using System.Threading.Tasks;

namespace Backgroundtasks_IHostedServiceandBackgroundService.Model
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}