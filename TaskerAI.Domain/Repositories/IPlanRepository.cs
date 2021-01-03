namespace TaskerAI.Domain
{
    public interface IPlanRepository
    {
        Plan GetPlan(int id);

        Plan CreatePlan(Plan plan);
    }
}
