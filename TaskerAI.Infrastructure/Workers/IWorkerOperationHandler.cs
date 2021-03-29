namespace TaskerAI.Infrastructure.Workers
{
    using System.Threading.Tasks;

    public interface IWorkerOperationHandler
    {
        string OperationEntity { get; }
        Task HandleAsync(WorkerOperation operation);
    }
}