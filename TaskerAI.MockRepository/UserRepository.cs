namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Domain;
    using TaskerAI.MockRepository.MockData;
    using Threading = System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        public async Threading.Task<User> GetAsync(int id) => await Threading.Task.FromResult(UserMockData.GetUserList().FirstOrDefault(u => u.Id == id));
        public async Threading.Task<User> CreateAsync(User user) => await Threading.Task.FromResult(new User(1, user.FirstName, user.LastName, user.Email));
        public Threading.Task<User> AcceptPlanAsync() => throw new NotImplementedException();
        public async Threading.Task<IEnumerable<User>> GetAsync() => await Threading.Task.FromResult(UserMockData.GetUserList());


    }
}
