namespace TaskerAI.MockRepository
{
    using System;
    using TaskerAI.Domain;

    public class UserRepository : IUserRepository
    {
        public User AcceptPlan() => throw new NotImplementedException();
        public User CreateUser(User user) => new User(1, user.FirstName, user.LastName, user.Email);
        public User GetUser(int id) => new User(1, "FirstName", "LastName", "Email");
    }
}
