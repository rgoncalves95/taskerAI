namespace TaskerAI.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class UserRepository : IUserRepository
    {
        public Task<IEnumerable<User>> GetAsync() => throw new NotImplementedException();
        public Task<User> GetAsync(int id) => throw new NotImplementedException();
        public Task<User> CreateAsync(User user) => throw new NotImplementedException();
        public Task<User> AcceptPlanAsync() => throw new NotImplementedException();
    }
}
