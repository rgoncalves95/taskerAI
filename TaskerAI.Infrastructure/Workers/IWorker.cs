namespace TaskerAI.Infrastructure.Workers
{
    using System.Threading.Tasks;

    public interface IWorker
    {
        string Id { get; }
        Task RunAsync(params string[] operationIds);
    }
}
