namespace TaskerAI.Application.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RouteResult
    {
        public int StartTask { get; set; }
        public float TotalDistance { get; set; }

        public int TaskFailed => this.TaskResults.Where(p => p.SecondsLost.HasValue).Count();

        public int TotalLostTime => this.TaskResults.Sum(p => p.SecondsLost ?? 0);


        public List<TaskResult> TaskResults { get; } = new List<TaskResult>();
    }

    internal class TaskResult
    {
        public int Id { get; set; }

        public int? SecondsLost { get; set; }

        public DateTimeOffset To { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset EstimatedArrival { get; set; }
    }
}
