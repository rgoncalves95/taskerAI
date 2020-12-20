namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;

    public class PlanBuilderContext
    {
        public PlanBuilderContext(DateTimeOffset planStartDate, List<Task> tasks, int? maxTaskNumber = null, int? maxTimeInSeconds = null, Location location = null, int? radius = null)
        {
            PlanStartDate = planStartDate;
            Tasks = tasks;
            MaxTaskNumber = maxTaskNumber ?? tasks.Count;
            MaxTimeInSeconds = maxTimeInSeconds;
            Location = location;
            Radius = radius;
        }

        public List<Task> Tasks { get; }
        public int MaxTaskNumber { get; }
        public int? MaxTimeInSeconds { get; }
        public Location Location { get; }
        public int? Radius { get; }
        public DateTimeOffset PlanStartDate { get; }
    }
}
