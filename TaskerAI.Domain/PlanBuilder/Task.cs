namespace TaskerAI.Domain.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Task
    {
        public Guid Id { get; set; }

        public DateTime DueDate { get; set; }

        public int Duration { get; set; }

    }
}
