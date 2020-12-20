using System;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.Dapper
{
    public class PlanRepository : IPlanRepository
    {
        public Plan CreatePlan(Plan plan)
        {
            throw new NotImplementedException();
        }

        public Plan GetPlan(int id)
        {
            var sql = "select * from";

            return null;
        }
    }
}
