namespace TaskerAI.Infrastructure.Jobs
{
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Repositories;

    public class BatchOperationJob : IWorkerJob
    {
        private readonly IWorkerOperationRepository repository;

        public BatchOperationJob(IWorkerOperationRepository repository) => this.repository = repository;

        public string Id => "F9D7AEFF-7D14-4528-A007-023C04B857E9";

        public Task RunAsync(params string[] operationIds) => throw new System.NotImplementedException();
    }
}
