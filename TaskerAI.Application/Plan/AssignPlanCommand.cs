namespace TaskerAI.Application
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class AssignPlanCommand : IRequest<Plan>
    {
        public AssignPlanCommand(int id, int userId)
        {
            this.PlanId = id;
            this.UserId = userId;
        }

        public int PlanId { get; }
        public int UserId { get; }
    }

    public class AssignPlanCommandHandler : IRequestHandler<AssignPlanCommand, Plan>
    {
        private readonly IPlanRepository repo;

        public AssignPlanCommandHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Plan> Handle(AssignPlanCommand request, CancellationToken cancellationToken) => null;
    }
}