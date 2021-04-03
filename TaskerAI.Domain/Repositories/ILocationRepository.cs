namespace TaskerAI.Domain
{
    using System.Threading.Tasks;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    public interface ILocationRepository
    {
        Task<Paged<Location>> GetAsync
        (
            string alias,
            string[] tags,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );
        Task<Location> GetAsync(string latitude, string longitude, string door, string floor);
        Task<Location> CreateAsync(Location domainEntity);
        Task<Location> UpdateAsync(Location domainEntity);

        Paged<Location> Get
        (
            string alias,
            string[] tags,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        );
        Location Get(int id);
        Location Get(string latitude, string longitude, string door, string floor);
        Location Create(Location domainEntity);
        Location Update(Location domainEntity);
    }
}