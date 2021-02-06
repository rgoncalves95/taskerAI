namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskerAI.MockRepository.MockData;

    public class TaskRepository : Domain.ITaskRepository
    {
        private static readonly List<Domain.Task> Db = TaskMockData.CreateDummyTasks();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        public async Task<IEnumerable<Domain.Task>> GetAsync()
        {
            Func<Domain.Task, bool> filter = (t) => true;

            return await Task.FromResult(Db.Where(filter).ToList());
        }

        public async Task<Domain.Task> GetAsync(int id) => await Task.FromResult(Db.FirstOrDefault(t => t.Id == id));

        public async Task<Domain.Task> CreateAsync(Domain.Task domainEntity)
        {
            var @new = Domain.Task.Create
            (
                domainEntity.Name,
                domainEntity.Type,
                domainEntity.Location,
                domainEntity.Date,
                domainEntity.DueDate,
                domainEntity.DurationInSeconds,
                domainEntity.Notes,
                this.lastId + 1,
                domainEntity.Status,
                domainEntity.FinishDate
            );

            Db.Add(@new);

            return await Task.FromResult(@new);
        }

        public async Task<Domain.Task> UpdateAsync(Domain.Task domainEntity)
        {
            Domain.Task old = await GetAsync((int)domainEntity.Id);
            Db.Remove(old);

            return await CreateAsync(old);
        }

        public async Task DeleteAsync(int id) => Db.Remove(await GetAsync(id));

       
    }
}
