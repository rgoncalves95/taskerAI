using TaskerAI.Domain;

namespace TaskerAI.Persistence
{
    public interface IPlanRepository
    {
        Plan GetPlan(int id);

        Plan CreatePlan(Plan plan);
    }
}
