using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.MockRepository
{
    public class PlanRepository : IPlanRepository
    {
        public Plan CreatePlan(Plan plan) => new Plan(1, plan.Name);
        public Plan GetPlan(int id) => FakerFactory.CreatePlan(id);

       
    }
}
