using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{

    public class Availability
    {

        public int Id { get; private set; }
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset EndDate { get; private set; }

        public Assignee User { get; private set; }

    public Availability(int id, DateTimeOffset startDate, DateTimeOffset endDate, Assignee user)
        {
            this.Id = id;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.User = user;
        }



    }


}