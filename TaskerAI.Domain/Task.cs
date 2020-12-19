using System;

namespace TaskerAI.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public TaskType Type { get; set; }
        public int Status { get; set; }
        public DateTimeOffset PlannedEndDate { get; set; }
        public Location Location { get; set; }
        public DateTimeOffset StartDate{ get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int Order { get; set; }

        public virtual void Cancel()
        {

        }

        public virtual void Finish()
        {

        }

    }
}