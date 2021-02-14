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
        public static readonly List<Location> Db;
        private readonly int lastId = Db.Max(t => t.Id) ?? 0;
        static LocationRepository() => Db = LocationMockData.DatabaseSeed().ToList();

        public Task<Paged<Location>> GetAsync(string alias, string[] tags, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            IQueryable<Location> query = Db.AsQueryable();

            var filter = new List<Expression<Func<Location, bool>>>();

            if (!string.IsNullOrWhiteSpace(alias))
            {
                filter.Add(t => (t.Alias ?? string.Empty).Contains(alias, StringComparison.OrdinalIgnoreCase));
            }

            if (tags.SafeAny())
            {
                filter.Add(t => tags.Intersect(t.Tags, StringComparer.FromComparison(StringComparison.OrdinalIgnoreCase)).Any());
            }

            return Task.FromResult(GetPaged(query, filter, pageSize, pageIndex, sortBy, sortAs));
        }
    }
}
