namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.Infrastructure.Workers;

    public class WorkerOperationStatusRepository : PagedRepository, IWorkerOperationStatusRepository
    {
        private static readonly List<WorkerOperationStatus> Db;

        static WorkerOperationStatusRepository() => Db = new List<WorkerOperationStatus>();

        public Task<Paged<WorkerOperationStatus>> GetAsync(string operationId, int? status, string failureReason, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            IQueryable<WorkerOperationStatus> query = Db.AsQueryable();

            var filter = new List<Expression<Func<WorkerOperationStatus, bool>>>();

            if (!string.IsNullOrWhiteSpace(operationId))
            {
                filter.Add(t => t.OperationId.ToLowerInvariant().Contains(operationId.ToLowerInvariant()));
            }

            if (status.HasValue)
            {
                filter.Add(t => t.Status == status);
            }

            if (status.HasValue)
            {
                filter.Add(t => t.FailureReasons.Any(fr => fr.ToLowerInvariant().Contains(operationId.ToLowerInvariant())));
            }

            return Task.FromResult(GetPaged(query, filter, pageSize, pageIndex, sortBy, sortAs));
        }

        public Task CreateAsync(WorkerOperation operation, List<string> failureReasons)
        {
            Db.Add(new WorkerOperationStatus { OperationId = operation.Id, Status = 1, FailureReasons = failureReasons });

            return Task.CompletedTask;
        }
    }
}
