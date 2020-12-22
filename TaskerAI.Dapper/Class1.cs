namespace TaskerAI.Dapper
{
    using System;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class PlanRepository : IPlanRepository
    {
        public Plan CreatePlan(Plan plan) => throw new NotImplementedException();

        public Plan GetPlan(int id)
        {
            return null;
        }
    }
}
