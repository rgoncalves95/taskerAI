namespace TaskerAI.Domain
{
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    public interface ITaskTypeRepository
    {
        Task<Paged<TaskType>> GetAsync
        (
            string name,
            double? cost,
            int? duration,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );
        Task<TaskType> GetAsync(int id);
        Task<TaskType> CreateAsync(TaskType domainEntity);
        Task<TaskType> UpdateAsync(TaskType domainEntity);
        Task<bool> DeleteAsync(int id);

        Paged<TaskType> Get
        (
            string name,
            double? cost,
            int? duration,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );
        TaskType Get(int id);
        TaskType Create(TaskType domainEntity);
        TaskType Update(TaskType domainEntity);
        bool Delete(int id);

    }
}
