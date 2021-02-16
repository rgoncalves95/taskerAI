namespace TaskerAI.MockRepository
{
    using System;
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.Infrastructure.Workers;

    public class WorkerOperationRepository : IWorkerOperationRepository
    {
        public Task<WorkerOperation> GetAsync(string id) => throw new NotImplementedException();
        public Task<string> CreateAsync(string jobId, string entityType, string contentType, byte[] content) => throw new NotImplementedException();
    }
}
