namespace TaskerAI.Infrastructure.Workers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Hangfire;
    using TaskerAI.Infrastructure.Repositories;

    [AutomaticRetry(Attempts = 0)]
    public class BatchOperationWorker : IWorker
    {
        private readonly IWorkerOperationRepository repository;
        private readonly IEnumerable<IWorkerOperationHandler> handlers;

        public BatchOperationWorker(IWorkerOperationRepository repository, IEnumerable<IWorkerOperationHandler> handlers)
        {
            this.repository = repository;
            this.handlers = handlers;
        }

        public string Id => "f9d7aeff-7d14-4528-a007-023c04b857e9";

        public async Task RunAsync(params string[] operationIds)
        {
            foreach (string operationId in operationIds)
            {
                WorkerOperation operation = await this.repository.GetAsync(operationId);

                var operationHandlers = this.handlers.Where(h => h.OperationEntity == operation.Entity).ToList();

                await Task.WhenAll(operationHandlers.Select(handler => handler.HandleAsync(operation)));
            }
        }
    }
}
