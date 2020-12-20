using System;
using TaskerAI.Api.Models;
using TaskerAI.Domain;
using TaskerAI.Infrastructure;

namespace TaskerAI.Api.Mapper
{
    public class PlanMapper : IMapper<Plan, PlanModel>
    {
        public void Map<Tin, Tout>(Tin from, Tout to)
        {
            throw new NotImplementedException();
        }
    }
}
