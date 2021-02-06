namespace TaskerAI.Api.Mapper
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;
    using TaskerAI.Domain;

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

        public void Map(IEnumerable<Plan> from, IEnumerable<PlanModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<PlanModel> Map(IEnumerable<Plan> from) => from.Select(f => Map(f)).ToArray();
    }
}
