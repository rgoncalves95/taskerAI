using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Assignee : User
    {

        public List<Availability> ListAvailability { get; private set; }

        internal Assignee(int id, string firstName, string lastName, string email, List<Availability> listAvailability) 
            : base(id, firstName, lastName, email) => ListAvailability = listAvailability;

        internal void AddAvailability(Availability availability) => ListAvailability.Add(availability);

        internal void NotifyPlanAssigned()
        {

        }

        internal virtual List<Plan> GetPlans()
        {
            var result = new List<Plan>();


            return result;

        }
    }
}
