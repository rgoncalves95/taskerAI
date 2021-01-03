namespace TaskerAI.Domain
{
    using System;

    public class TaskRoute
    {
        internal static TaskRoute Create(Task from, Task to, decimal distance, int timeInSeconds) => new TaskRoute(from, to, distance, timeInSeconds);

        private TaskRoute(Task from, Task to, decimal distance, int timeInSeconds)
        {
            this.From = from;
            this.To = to;
            this.Distance = distance;
            this.TimeInSeconds = timeInSeconds;
        }

        public Task From { get; private set; }
        public Task To { get; private set; }
        public decimal Distance { get; private set; }
        public int TimeInSeconds { get; private set; }
        public DateTimeOffset EstimatedStartDate { get; private set; }
        public DateTimeOffset EstimatedEndDate { get; private set; }
        public int RouteExecutionTimeInSeconds => this.From.DurationInSeconds + this.TimeInSeconds;

        internal void Estimate(DateTimeOffset estimatedStartDate)
        {
            this.EstimatedStartDate = estimatedStartDate;
            this.EstimatedEndDate = estimatedStartDate.AddSeconds(this.From.DurationInSeconds);
        }
    }
}
