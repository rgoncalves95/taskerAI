namespace TaskerAI.Domain
{
    internal interface IPlanBuilder
    {
        Plan CreatePlan(PlanBuilderContext context);
    }
}