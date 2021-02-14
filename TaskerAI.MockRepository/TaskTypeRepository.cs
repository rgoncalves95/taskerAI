namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.MockRepository.MockData;
    using Task = System.Threading.Tasks.Task;

    public class TaskTypeRepository : PagedRespository, ITaskTypeRepository
    {
        private static readonly List<TaskType> Db = TaskTypeMockData.DatabaseSeed().ToList();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        public Task<Paged<TaskType>> GetAsync(string name, double? cost, int? duration, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            IQueryable<TaskType> query = Db.AsQueryable();

            var filter = new List<Expression<Func<TaskType, bool>>>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                filter.Add(t => t.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            if (cost.HasValue)
            {
                filter.Add(t => t.Cost == cost.Value);
            }

            if (duration.HasValue)
            {
                filter.Add(t => t.Duration == duration.Value);
            }

            return Task.FromResult(GetPaged(query, filter, pageSize, pageIndex, sortBy, sortAs));
        }

        public Task<TaskType> GetAsync(int id) => Task.FromResult(Db.FirstOrDefault(t => t.Id == id));

        public Task<TaskType> CreateAsync(TaskType domainEntity)
        {
            var @new = TaskType.Create(domainEntity.Name, domainEntity.Cost, domainEntity.Duration, this.lastId + 1);
            Db.Add(@new);

            return Task.FromResult(@new);
        }

        public Task<TaskType> UpdateAsync(TaskType domainEntity)
        {
            TaskType item = Db.FirstOrDefault(e => e.Id == domainEntity.Id);

            if (item == null)
            {
                return Task.FromResult<TaskType>(null);
            }

            Db.Remove(item);
            Db.Add(domainEntity);

            return Task.FromResult(domainEntity);
        }

        public Task<bool> DeleteAsync(int id) => Task.FromResult(Db.RemoveAll(e => e.Id == id) == 1);
    }
}
