using System;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.Dapper
{
    public class PlanRepository : IPlanRepository
    {
        public IPlan CreatePlan(IPlan plan)
        {
            throw new NotImplementedException();
        }

        public IPlan GetPlan(int id)
        {
            var sql = "select * from";

            return null;
        }
    }
}
