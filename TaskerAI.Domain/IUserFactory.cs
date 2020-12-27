namespace TaskerAI.Domain
{
    public interface IUserFactory
    {
        Assignee CreateAssignee(User user);
    }
}