namespace TaskerAI.Api.Mapper
{
    using TaskerAI.Api.Models;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;

    public class PlanMapper : IMapper<Plan, PlanModel>
    {
        public void Map(Plan from, PlanModel to)
        {

        }

        public PlanModel Map(Plan from)
        {
            var to = new PlanModel();

            Map(from, to);

            return to;
        }
    }
}
