namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain.Repositories;

    public interface ITaskRepository : IDomainRepository<Entities.Task>
    {
        Task<Paged<Entities.Task>> GetAsync(
            string name,
            int? type,
            DateTimeOffset? intervalStart,
            DateTimeOffset? intervalEnd,
            int? status,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );

        Task<Entities.Task> GetAsync(int id);

        Task<IEnumerable<Entities.Task>> GetAsync(IEnumerable<int> ids);
    }
}
