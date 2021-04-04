namespace TaskerAI.Domain
{
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain.Repositories;

    public interface ILocationRepository : IDomainRepository<Entities.Location>
    {
        Task<Paged<Entities.Location>> GetAsync
        (
            string alias,
            string[] tags,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );

        Task<Entities.Location> GetAsync(string latitude, string longitude, string door, string floor);
    }
}