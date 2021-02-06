namespace TaskerAI.MockRepository.MockData
{
    using System.Collections.Generic;
    using TaskerAI.Domain;

    internal class UserMockData
    {
        public static List<User> GetUserList() => new List<User> { new User(1, "Rui", "Silva", "Rui.Silva@tskrai.com"), new User(2, "Ricardo", "Goncalves", "Ricardo.Goncalves@tskrai.com"), new User(3, "Hugo", "Sa", "Hugo.Sa@tskrai.com") };
    }
}
