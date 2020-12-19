using TaskerAI.Domain;

namespace TaskerAI.Persistence
{
    public interface IPlanRepository
    {
        IPlan GetPlan(int id);

        IPlan CreatePlan(IPlan plan);
    }
}
