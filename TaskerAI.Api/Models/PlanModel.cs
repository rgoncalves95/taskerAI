namespace TaskerAI.Api.Models
{
    using System.Collections.Generic;

    public class PlanModel
    {
        public List<int> TaskIds { get; set; }
        public int LocationId { get; set; }
        public int MaxTimeForPlan { get; set; }
        public int MaxNumberOfTasks { get; set; }
    }
}
