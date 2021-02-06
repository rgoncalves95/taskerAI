namespace TaskerAI.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(int id);

        Task<User> CreateAsync(User user);

        Task<User> AcceptPlanAsync();
    }
}
