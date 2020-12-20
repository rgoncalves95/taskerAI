using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public partial class Admin : Assignee
    {
        internal Admin(int id, string firstName, string lastName, string email, List<Availability> listAvailability) 
            : base(id, firstName, lastName, email, listAvailability)
        {

        }

        internal void NotifyPlanAccepted()
        {

        }

        internal void NotifyPlanRefused()
        {

        }

        internal override List<Plan> GetPlans()
        {
            var result = new List<Plan>();


            return result;
        }
    }
}
