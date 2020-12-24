using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.Controllers
{
    public class AssignPlanCommand : IRequest
    {
        public AssignPlanCommand(int id, int userId)
        {
            PlanId = id;
            UserId = userId;
        }

        public int PlanId { get; }
        public int UserId { get; }
    }

    public class AssignPlanCommandHandler : IRequestHandler<AssignPlanCommand>
    {
        private readonly IPlanRepository repo;

        public AssignPlanCommandHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Unit> Handle(AssignPlanCommand request, CancellationToken cancellationToken)
        {
            var plan = Plan.Create("");

            return Unit.Value;
        }
    }
}