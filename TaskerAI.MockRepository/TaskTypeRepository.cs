namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.MockRepository.MockData;
    using Task = System.Threading.Tasks.Task;

    public class TaskTypeRepository : PagedRespository, ITaskTypeRepository
    {
        private static readonly List<TaskType> Db = TaskTypeMockData.DatabaseSeed().ToList();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        public Task<Paged<TaskType>> GetAsync(string name, double cost, double duration, int? pageSize, int? pageIndex, string sortBy, string sortAs) => throw new NotImplementedException();

        public Task<TaskType> GetAsync(int id) => throw new NotImplementedException();

        public async Task<TaskType> CreateAsync(TaskType domainEntity)
        {
            var @new = TaskType.Create(domainEntity.Name, domainEntity.Cost, domainEntity.Duration, this.lastId + 1);
            Db.Add(@new);

            return await Task.FromResult(@new);
        }

        public Task<TaskType> UpdateAsync(TaskType domainEntity) => throw new NotImplementedException();

        public TaskType DeleteAsync(int id) => throw new NotImplementedException();
    }
}
