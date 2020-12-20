using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Task
    {
        public int Id { get; private set; }
        public TaskType Type { get; private set; }
        public int Status { get; private set; }
        public DateTimeOffset PlannedEndDate { get; private set; }
        public Location Location { get; private set; }
        public DateTimeOffset StartDate{ get; private set; }
        public DateTimeOffset EndDate { get; private set; }
        public int Position { get; private set; }

        internal Task(int id, TaskType type, int status, DateTimeOffset plannedEndDate, Location location, DateTimeOffset startDate, DateTimeOffset endDate, int position)
        {
            this.Id = id;
            this.Type = type;
            this.Status = status;
            this.PlannedEndDate = plannedEndDate;
            this.Location = location;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Position = position;

        }

        internal virtual void Cancel()
        {

        }

        internal virtual void Finish()
        {

        }

    }
}