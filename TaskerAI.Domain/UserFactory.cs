namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class UserFactory : IUserFactory
    {
        public Assignee CreateAssignee(User user)
        {
            return new Assignee(user.Id, user.FirstName, user.LastName, user.Email, null);
        }
    }
}
