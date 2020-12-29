namespace TaskerAI.Domain
{
    using System.Runtime.CompilerServices;

    public class User
    {

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }


        internal User(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;

        }
    }
}
