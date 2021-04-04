namespace TaskerAI.Domain.Repositories
{
    using System.Threading.Tasks;

    public interface IDomainRepository<T> where T : Entities.BaseEntity
    {
        Task<T> CreateAsync(T domainEntity);
        Task<T> UpdateAsync(T domainEntity);
        Task<bool> DeleteAsync(int id);
    }
}
