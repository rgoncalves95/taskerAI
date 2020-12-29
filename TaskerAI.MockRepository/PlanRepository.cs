namespace TaskerAI.MockRepository
{
    using TaskerAI.Domain;

    public class PlanRepository : IPlanRepository
    {
        public Plan CreatePlan(Plan plan) => null;
        public Plan GetPlan(int id) => FakerFactory.CreatePlan(id);
    }
}
