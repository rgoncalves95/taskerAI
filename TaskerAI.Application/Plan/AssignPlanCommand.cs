namespace TaskerAI.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class AssignPlanCommand : IRequest<Plan>
    {
        public AssignPlanCommand(int id, int userId)
        {
            PlanId = id;
            UserId = userId;
        }

        public int PlanId { get; }
        public int UserId { get; }
    }

    public class AssignPlanCommandHandler : IRequestHandler<AssignPlanCommand,Plan>
    {
        private readonly IPlanRepository repo;

        public AssignPlanCommandHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Plan> Handle(AssignPlanCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}