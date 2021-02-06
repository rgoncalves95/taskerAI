namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.MockRepository.MockData;

    public class TaskRepository : PagedRespository, Domain.ITaskRepository
    {
        private static readonly List<Domain.Task> Db = TaskMockData.DatabaseSeed().ToList();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        public async Task<Paged<Domain.Task>> GetAsync
        (
            string name,
            int? type,
            DateTimeOffset? intervalStart,
            DateTimeOffset? intervalEnd,
            int? status,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        )
        {
            IQueryable<Domain.Task> query = Db.AsQueryable();

            var filter = new List<Expression<Func<Domain.Task, bool>>>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                filter.Add(t => t.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            if (type.HasValue)
            {
                filter.Add(t => t.Type.Id == type.Value);
            }

            if (intervalStart.HasValue)
            {
                filter.Add(t => t.Date.Date >= intervalStart.Value.Date);
            }

            if (intervalEnd.HasValue)
            {
                filter.Add(t => t.Date.Date <= intervalEnd.Value.Date);
            }

            if (status.HasValue)
            {
                filter.Add(t => (int)t.Status.Value == status.Value);
            }

            return await Task.FromResult(GetPaged(query, filter, pageSize, pageIndex, sortBy, sortAs));
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
