namespace TaskerAI.Infrastructure.Workers
{
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Repositories;

    public class BatchOperationWorker : IWorker
    {
        private readonly IWorkerOperationRepository repository;

        public BatchOperationWorker(IWorkerOperationRepository repository) => this.repository = repository;

        public string Id => "F9D7AEFF-7D14-4528-A007-023C04B857E9";

        public Task RunAsync(params string[] operationIds) => throw new System.NotImplementedException();
    }
}
