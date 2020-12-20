namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;

    interface IPlanBuilder
    {
        Plan CreatePlan(PlanBuilderContext context);
    }
}