using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskerAI.Domain
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(int id);

        Task<User> CreateAsync(User user);

        Task<User> AcceptPlanAsync();
    }
}
