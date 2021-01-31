namespace TaskerAI.Domain
{
    using System.Collections.Generic;
    using Threading = System.Threading.Tasks;

    public interface ITaskRepository
    {
        Threading.Task<IEnumerable<Task>> GetAsync();
        Threading.Task<Task> GetAsync(int id);
        Threading.Task<Task> CreateAsync(Task domainEntity);
        Threading.Task<Task> UpdateAsync(Task domainEntity);
        Threading.Task DeleteAsync(int id);
    }
}
