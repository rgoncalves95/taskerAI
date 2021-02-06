namespace TaskerAI.Application.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RouteResult
    {
        public Guid StartTask { get; set; }
        public int TotalDistance { get; set; }

        public int TaskFailed => this.TaskResults.Where(p => p.SecondsLost.HasValue).Count();

        public int TotalLostTime => this.TaskResults.Sum(p => p.SecondsLost.HasValue ? p.SecondsLost.Value : 0);


        public List<TaskResult> TaskResults { get; } = new List<TaskResult>();
    }

    internal class TaskResult
    {
        public Guid Id { get; set; }

        public int? SecondsLost { get; set; }

        public DateTime To { get; set; }

        public DateTime From { get; set; }

        public DateTime EstimatedArrival { get; set; }
    }
}
