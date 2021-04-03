namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure.Repositories;
    using TaskerAI.MockRepository.MockData;

    public class TaskRepository : PagedRespository, Domain.ITaskRepository
    {
        private static readonly List<Domain.Entities.Task> Db;
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;
        private readonly ILocationRepository locationRepository;

        static TaskRepository() => Db = TaskMockData.DatabaseSeed().ToList();

        public TaskRepository(ILocationRepository locationRepository) => this.locationRepository = locationRepository;

        public Task<Paged<Domain.Entities.Task>> GetAsync
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
            IQueryable<Domain.Entities.Task> query = Db.AsQueryable();

            var filter = new List<Expression<Func<Domain.Entities.Task, bool>>>();

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
                filter.Add(t => (int)t.Status == status.Value);
            }

            return Task.FromResult(GetPaged(query, filter, pageSize, pageIndex, sortBy, sortAs));
        }

        public Task<Domain.Entities.Task> GetByIdAsync(int id) => Task.FromResult(Db.FirstOrDefault(t => t.Id == id));

        public async Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task domainEntity)
        {
            Domain.Entities.Location location =
                await this.locationRepository.GetAsync(domainEntity.Location.Latitude,
                                                       domainEntity.Location.Longitude,
                                                       domainEntity.Location.Door,
                                                       domainEntity.Location.Floor);

            if (location != null)
            {
                location.AddAliases(domainEntity.Location.Aliases.ToArray());
                location.AddTags(domainEntity.Location.Tags.ToArray());

                location = await this.locationRepository.UpdateAsync(location);
            }
            else
            {
                location = await this.locationRepository.CreateAsync(domainEntity.Location);
            }

            var @new = Domain.Entities.Task.Create
            (
                domainEntity.Name,
                domainEntity.Type,
                location,
                domainEntity.Date,
                domainEntity.DueDate,
                domainEntity.DurationInSeconds,
                domainEntity.Notes,
                domainEntity.Status,
                domainEntity.FinishDate,
                this.lastId + 1
            );

            Db.Add(@new);

            return await Task.FromResult(@new);
        }

        public Task<Domain.Entities.Task> UpdateAsync(Domain.Entities.Task domainEntity)
        {
            Domain.Entities.Task item = Db.FirstOrDefault(e => e.Id == domainEntity.Id);

            if (item == null)
            {
                return Task.FromResult<Domain.Entities.Task>(null);
            }

            Db.Remove(item);
            Db.Add(domainEntity);

            return Task.FromResult(domainEntity);
        }

        public Task<bool> DeleteAsync(int id) => Task.FromResult(Db.RemoveAll(e => e.Id == id) == 1);
    }
}
