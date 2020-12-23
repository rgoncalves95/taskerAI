namespace TaskerAI.Api.Models
{
    using System.Collections.Generic;

    public class PlanModel
    {
        public int Id { get; set; }
        public List<int> TaskIds { get; set; }
        public int LocationId { get; set; }
        public int MaxTimeForPlan { get; set; }
        public int MaxNumberOfTasks { get; set; }
        public int AssigneeId { get; set; }
        public int SupervisorId { get; set; }
    }
}
