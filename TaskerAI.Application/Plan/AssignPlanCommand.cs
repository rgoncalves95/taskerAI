namespace TaskerAI.Application
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class AssignPlanCommand : IRequest
    {

        public int PlanId { get; set; }
        public int UserId { get; set; }
        public AssignPlanCommand(int planId, int userId)
        {
            PlanId = planId;
            UserId = userId;
        }
     
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
