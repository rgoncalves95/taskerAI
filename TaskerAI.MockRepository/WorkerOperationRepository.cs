namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.Infrastructure.Workers;

    public class WorkerOperationRepository : IWorkerOperationRepository
    {
        private static readonly List<WorkerOperation> Db;

        static WorkerOperationRepository() => Db = new List<WorkerOperation>();

        public Task<WorkerOperation> GetAsync(string id) => Task.FromResult(Db.FirstOrDefault(o => o.Id == id));

        public Task<string> CreateAsync(string jobId, string entityType, string contentType, byte[] content)
        {
            var operation = new WorkerOperation { Id = Guid.NewGuid().ToString(), JobId = jobId, Entity = entityType, ContentType = contentType, Content = content };
            Db.Add(operation);

            return Task.FromResult(operation.Id);
        }
    }
}
