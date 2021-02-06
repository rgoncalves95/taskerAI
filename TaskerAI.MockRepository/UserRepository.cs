namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using Threading = System.Threading.Tasks;
    using TaskerAI.Domain;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        public async Threading.Task<User> GetAsync(int id) => await Threading.Task.FromResult(GetUserList().FirstOrDefault(u => u.Id == id));
        public async Threading.Task<User> CreateAsync(User user) => await Threading.Task.FromResult(new User(1, user.FirstName, user.LastName, user.Email));
        public Threading.Task<User> AcceptPlanAsync() => throw new NotImplementedException();
        public async Threading.Task<IEnumerable<User>> GetAsync() => await Threading.Task.FromResult(GetUserList());

        private List<User> GetUserList()
        {
            return new List<User> { new User(1, "Rui", "Silva", "Rui.Silva@tskrai.com"), new User(2, "Ricardo", "Goncalves", "Ricardo.Goncalves@tskrai.com"), new User(3, "Hugo", "Sa", "Hugo.Sa@tskrai.com") };
        }
    }
}
