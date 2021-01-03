namespace TaskerAI.Domain
{
    internal static class UserFactory
    {
        public static Assignee CreateAssignee(User user) => new Assignee(user.Id, user.FirstName, user.LastName, user.Email, null);
    }
}
