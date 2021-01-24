namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TaskRepository : Domain.ITaskRepository
    {
        private static readonly List<Domain.Task> Db = new List<Domain.Task>();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        public async Task<IEnumerable<Domain.Task>> GetAsync(string name, int? type, DateTimeOffset? intervalStart, DateTimeOffset? intervalEnd, int? status)
        {
            var query = Db.AsQueryable();

            if (string.IsNullOrWhiteSpace(name))
            {
                query.Where(t => t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (type.HasValue)
            {
                query.Where(t => t.Type.Id == type.Value);
            }

            if (intervalStart.HasValue)
            {
                query.Where(t => t.Date.Date >= intervalStart.Value.Date);
            }

            if (intervalEnd.HasValue)
            {
                query.Where(t => t.Date.Date <= intervalEnd.Value.Date);
            }

            if (status.HasValue)
            {
                query.Where(t => (int)t.Status.Value == status.Value);
            }

            return await Task.FromResult(query.ToList());
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
