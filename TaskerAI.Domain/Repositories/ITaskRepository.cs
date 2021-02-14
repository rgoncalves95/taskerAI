namespace TaskerAI.Domain
{
    using System;
    using System.Threading.Tasks;
    using TaskerAI.Common;

    public interface ITaskRepository
    {
        Task<Paged<Task>> GetAsync(
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
        Task<Task> GetAsync(int id);
        Task<Task> CreateAsync(Task domainEntity);
        Task<Task> UpdateAsync(Task domainEntity);
        Task<bool> DeleteAsync(int id);
    }
}
