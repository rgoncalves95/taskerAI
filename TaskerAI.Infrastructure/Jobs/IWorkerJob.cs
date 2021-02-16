namespace TaskerAI.Infrastructure.Jobs
{
    using System.Threading.Tasks;

    public interface IWorkerJob
    {
        string Id { get; }
        Task RunAsync(params string[] operationIds);
    }
}
