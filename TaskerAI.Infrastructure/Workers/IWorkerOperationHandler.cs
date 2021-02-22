namespace TaskerAI.Infrastructure.Workers
{
    public interface IWorkerOperationHandler
    {
        string OperationEntity { get; }
        void Handle(WorkerOperation operation);
    }
}