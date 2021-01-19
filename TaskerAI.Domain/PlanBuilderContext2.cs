namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;

    public class PlanBuilderContext2
    {
        public PlanBuilderContext2(DateTimeOffset planStartDate, List<Task> tasks, int? maxTaskNumber = null, int? maxTimeInSeconds = null, Location location = null, int? radius = null)
        {
            this.PlanStartDate = planStartDate;
            this.Tasks = tasks;
            this.MaxTaskNumber = maxTaskNumber ?? tasks.Count;
            this.MaxTimeInSeconds = maxTimeInSeconds;
            this.Location = location;
            this.Radius = radius;
        }

        public List<Task> Tasks { get; }
        public int MaxTaskNumber { get; }
        public int? MaxTimeInSeconds { get; }
        public Location Location { get; }
        public int? Radius { get; }
        public DateTimeOffset PlanStartDate { get; }
    }
}
