namespace TaskerAI.Domain.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Route
    {
        public Guid From { get; set; }

        public Guid To { get; set; }

        public int Distance { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
