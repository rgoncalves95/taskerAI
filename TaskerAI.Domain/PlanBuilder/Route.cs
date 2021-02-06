namespace TaskerAI.Domain.PlanBuilder
{
    using System;

    internal class Route
    {
        public Guid From { get; set; }

        public Guid To { get; set; }

        public int Distance { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
