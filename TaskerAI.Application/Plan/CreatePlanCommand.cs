
namespace TaskerAI.Application
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class CreatePlanCommand : IRequest
    {
        public List<int> TaskIds { get; set; }
        public int LocationId { get; set; }
        public int MaxTimeForPlan { get; set; }
        public int MaxNumberOfTasks { get; set; }
        public CreatePlanCommand(List<int> taskIds, int locationId, int maxTimeForPlan, int maxNumberOfTasks)
        {
            TaskIds = taskIds;
            LocationId = locationId;
            MaxTimeForPlan = maxTimeForPlan;
            MaxNumberOfTasks = maxNumberOfTasks;
        }
    }

    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand>
    {
        private readonly IPlanRepository repo;

        public CreatePlanCommandHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Unit> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = Plan.Create("");

            return Unit.Value;
        }
    }
}
