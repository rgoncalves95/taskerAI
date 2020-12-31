namespace TaskerAI.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAsync();
        Task<Task> GetAsync(int id);
        Task<Task> CreateAsync(Task domainEntity);
        Task<Task> UpdateAsync(Task domainEntity);
        System.Threading.Tasks.Task DeleteAsync(int id);
    }
}
