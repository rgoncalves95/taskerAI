namespace TaskerAI.Infrastructure.Workers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Repositories;

    public class BatchOperationWorker : IWorker
    {
        private readonly IWorkerOperationRepository repository;
        private readonly IEnumerable<IWorkerOperationHandler> handlers;

        public BatchOperationWorker(IWorkerOperationRepository repository, IEnumerable<IWorkerOperationHandler> handlers)
        {
            this.repository = repository;
            this.handlers = handlers;
        }

        public string Id => "F9D7AEFF-7D14-4528-A007-023C04B857E9";

        public async Task RunAsync(params string[] operationIds)
        {
            foreach (string operationId in operationIds)
            {
                WorkerOperation operation = await this.repository.GetAsync(operationId);

                var operationHandlers = this.handlers.Where(h => h.OperationEntity == operation.Entity).ToList();

                foreach (var handler in operationHandlers)
                {
                    handler.Handle(operation);
                }
            }
        }
    }
}
