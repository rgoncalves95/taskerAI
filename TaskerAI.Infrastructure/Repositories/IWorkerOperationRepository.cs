﻿namespace TaskerAI.Infrastructure.Repositories
{
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Jobs;

    public interface IWorkerOperationRepository
    {
        Task<WorkerOperation> GetAsync(string id);
        Task<string> CreateAsync(string jobId, string entityType, string contentType, byte[] content);
    }
}