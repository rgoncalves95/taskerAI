namespace TaskerAI.Application.PlanBuilder
{
    using System;

    internal class Route
    {
        public int From { get; set; }
        public int To { get; set; }
        public float Distance { get; set; }
        public float TimeInSeconds { get; set; }
    }
}
