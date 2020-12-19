using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.Application
{
    public class GetPlanQueryHandler : IRequestHandler<GetPlanQuery, IPlan>
    {
        private readonly IPlanRepository repo;

        public GetPlanQueryHandler(IPlanRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IPlan> Handle(GetPlanQuery request, CancellationToken cancellationToken)
        {
            var plan = repo.GetPlan(0);

            return plan;
        }
    }
}
