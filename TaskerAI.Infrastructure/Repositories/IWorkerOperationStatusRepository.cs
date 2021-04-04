namespace TaskerAI.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Workers;

    public interface IWorkerOperationStatusRepository
    {
        Task<Paged<WorkerOperationStatus>> GetAsync(string operationId, int? status, string failureReason, int? pageSize, int? pageIndex, string sortBy, string sortAs);
        Task CreateAsync(WorkerOperation operation, List<string> failureReasons);
    }
}
