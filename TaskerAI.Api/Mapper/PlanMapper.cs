using System;
using TaskerAI.Api.Models;
using TaskerAI.Domain;
using TaskerAI.Infrastructure;

namespace TaskerAI.Api.Mapper
{
    public class PlanMapper : IMapper<Plan, PlanModel>
    {
        public void Map(Plan from, PlanModel to)
        {
            throw new NotImplementedException();
        }

        public PlanModel Map(Plan from)
        {
            var to = new PlanModel();

            this.Map(from, to);

            return to;
        }
    }
}
