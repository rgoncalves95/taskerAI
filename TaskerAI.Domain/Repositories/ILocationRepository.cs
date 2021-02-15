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
    }
}