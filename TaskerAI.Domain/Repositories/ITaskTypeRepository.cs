namespace TaskerAI.Domain
{
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;
    using TaskerAI.Domain.Repositories;

    public interface ITaskTypeRepository : IDomainRepository<TaskType>
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
    }
}
