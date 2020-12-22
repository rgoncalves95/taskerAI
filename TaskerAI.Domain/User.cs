using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class User
    {

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }


        internal User(int id, string firstName, string lastName, string email, string password)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;

        }

    }




    public class Assignee : User
    {

        public List<Availability> ListAvailability { get; private set; }

        internal Assignee(int id, string firstName, string lastName, string email, string password, List<Availability> listAvailability) : base(id, firstName, lastName, email, password)
        {

            this.ListAvailability = listAvailability;
        }

        internal void AddAvailability(Availability availability)
        {

            this.ListAvailability.Add(availability);
        }

        internal void NotifyPlanAssigned()
        {

        }
    }


    public partial class Admin : Assignee
    {
        internal Admin(int id, string firstName, string lastName, string email, string password, List<Availability> listAvailability) : base(id, firstName, lastName, email, password, listAvailability)
        {

        }

        internal void NotifyPlanAccepted()
        {

        }

        internal void NotifyPlanRefused()
        {

        }

        internal List<Plan> GetPlans()
        {
            var result = new List<Plan>();


            return result;

        }
    }
}
