namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAsync(string name, int? type, DateTimeOffset? intervalStart, DateTimeOffset? intervalEnd, int? status);
        Task<Task> GetAsync(int id);
        Task<Task> CreateAsync(Task domainEntity);
        Task<Task> UpdateAsync(Task domainEntity);
        System.Threading.Tasks.Task DeleteAsync(int id);
    }
}
