namespace TaskerAI.Domain.PlanBuilder
{
    using System;

    internal class Task
    {
        public Guid Id { get; set; }

        public DateTime DueDate { get; set; }

        public int Duration { get; set; }

    }
}
