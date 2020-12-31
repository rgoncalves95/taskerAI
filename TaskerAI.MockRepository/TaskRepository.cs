namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TaskRepository : Domain.ITaskRepository
    {
        private static readonly List<Domain.Task> Db = new List<Domain.Task>();
        private readonly int lastId = (int)Db.Max(t => t.Id);

        public async Task<IEnumerable<Domain.Task>> GetAsync()
        {
            Func<Domain.Task, bool> filter = null;

            return await Task.FromResult(Db.Where(filter).ToList());
        }

        public async Task<Domain.Task> GetAsync(int id)
        {
            return await Task.FromResult(Db.FirstOrDefault(t => t.Id == id));
        }

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
                lastId + 1,
                domainEntity.Status,
                domainEntity.FinishDate
            );
            
            Db.Add(@new);

            return await Task.FromResult(@new);
        }

        public async Task<Domain.Task> UpdateAsync(Domain.Task domainEntity)
        {
            var old = await GetAsync((int)domainEntity.Id);
            Db.Remove(old);

            return await this.CreateAsync(old);
        }

        public async Task DeleteAsync(int id)
        {
            Db.Remove(await GetAsync(id));
        }
    }
}
