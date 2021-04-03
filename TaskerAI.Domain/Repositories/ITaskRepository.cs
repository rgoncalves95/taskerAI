namespace TaskerAI.Domain
{
    using System;
    using System.Threading.Tasks;
    using TaskerAI.Common;

    public interface ITaskRepository
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
        Task<Entities.Task> CreateAsync(Entities.Task domainEntity);
        Task<Entities.Task> UpdateAsync(Entities.Task domainEntity);
        Task<bool> DeleteAsync(int id);


        Paged<Entities.Task> Get(
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
        Entities.Task Get(int id);
        Entities.Task Create(Entities.Task domainEntity);
        Entities.Task Update(Entities.Task domainEntity);
        bool Delete(int id);
    }
}
