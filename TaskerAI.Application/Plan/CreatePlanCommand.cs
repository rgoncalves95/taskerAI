namespace TaskerAI.Application
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class CreatePlanCommand : IRequest
    {
        public List<int> TaskIds { get; set; }
        public int LocationId { get; set; }
        public int MaxTimeForPlan { get; set; }
        public int MaxNumberOfTasks { get; set; }
        public CreatePlanCommand(List<int> taskIds, int locationId, int maxTimeForPlan, int maxNumberOfTasks)
        {
            this.TaskIds = taskIds;
            this.LocationId = locationId;
            this.MaxTimeForPlan = maxTimeForPlan;
            this.MaxNumberOfTasks = maxNumberOfTasks;
        }
    }

    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand>
    {
        private readonly IPlanRepository repo;

        public CreatePlanCommandHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Unit> Handle(CreatePlanCommand request, CancellationToken cancellationToken) => Unit.Value;
    }
}
