namespace TaskerAI.Persistence
{
    using TaskerAI.Domain;

    public interface IUserRepository
    {
        User GetUser(int id);

        User CreateUser(User user);

        User AcceptPlan();
    }
}
