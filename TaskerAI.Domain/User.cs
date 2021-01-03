namespace TaskerAI.Domain
{
    public class User
    {

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }


        internal User(int id, string firstName, string lastName, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;

        }
    }
}
