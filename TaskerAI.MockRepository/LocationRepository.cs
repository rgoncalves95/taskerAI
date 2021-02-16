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

    public class LocationRepository : PagedRespository, ILocationRepository
    {
        public static readonly List<Location> Db = LocationMockData.DatabaseSeed().ToList();
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;

        static LocationRepository() => Db = LocationMockData.DatabaseSeed().ToList();

        public Task<Paged<Location>> GetAsync(string alias, string[] tags, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            IQueryable<Location> query = Db.AsQueryable();

            var filter = new List<Expression<Func<Location, bool>>>();

            if (!string.IsNullOrWhiteSpace(alias))
            {
                filter.Add(t => t.Aliases.Any(s => s.Contains(alias, StringComparison.OrdinalIgnoreCase)));
            }

            if (tags.SafeAny())
            {
                filter.Add(t => tags.Intersect(t.Tags, StringComparer.OrdinalIgnoreCase).Any());
            }

            return Task.FromResult(GetPaged(query, filter, pageSize, pageIndex, sortBy, sortAs));
        }

        public Task<Location> GetAsync(string latitude, string longitude, string door, string floor)
        {
            return Task.FromResult(Db.FirstOrDefault(l => l.Latitude == latitude
                                                       && l.Longitude == longitude
                                                       && l.Door == door
                                                       && l.Floor == floor));
        }

        public Task<Location> CreateAsync(Location domainEntity)
        {
            var @new = Location.Create
            (
                domainEntity.Street,
                domainEntity.Door,
                domainEntity.Floor,
                domainEntity.ZipCode,
                domainEntity.City,
                domainEntity.Country,
                domainEntity.Latitude,
                domainEntity.Longitude,
                domainEntity.Aliases,
                domainEntity.Tags,
                this.lastId + 1
            );

            Db.Add(@new);

            return Task.FromResult(@new);
        }

        public Task<Location> UpdateAsync(Location domainEntity)
        {
            Location item = Db.FirstOrDefault(e => e.Id == domainEntity.Id);

            if (item == null)
            {
                return Task.FromResult<Location>(null);
            }

            Db.Remove(item);
            Db.Add(domainEntity);

            return Task.FromResult(domainEntity);
        }
    }
}
