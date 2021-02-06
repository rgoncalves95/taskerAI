namespace TaskerAI.Domain
{
    using System.Threading.Tasks;
    using TaskerAI.Common;

    public interface ITaskTypeRepository
    {
        Task<Paged<TaskType>> GetAsync(
            string name,
            double cost,
            double duration,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );
        Task<TaskType> GetAsync(int id);
        Task<TaskType> CreateAsync(TaskType domainEntity);
        Task<TaskType> UpdateAsync(TaskType domainEntity);
        TaskType DeleteAsync(int id);
    }
}
