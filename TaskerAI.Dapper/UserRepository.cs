namespace TaskerAI.Dapper
{
    using System;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class UserRepository : IUserRepository
    {
        public User AcceptPlan() => throw new NotImplementedException();
        public User CreateUser(User user) => throw new NotImplementedException();
        public User GetUser(int id) => throw new NotImplementedException();
    }
}
