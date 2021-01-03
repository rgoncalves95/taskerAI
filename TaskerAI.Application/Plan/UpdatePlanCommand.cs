namespace TaskerAI.Application
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdatePlanCommand : IRequest
    {
        public UpdatePlanCommand(int id, List<int> taskIds, int maxNumberOfTasks, int maxTimeForPlan, int locationId, int supervisorId, int assigneeId)
        {
            this.Id = id;
            this.TaskIds = taskIds;
            this.MaxNumberOfTasks = maxNumberOfTasks;
            this.MaxTimeForPlan = maxTimeForPlan;
            this.LocationId = locationId;
            this.SupervisorId = supervisorId;
            this.AssigneeId = assigneeId;
        }

        public int Id { get; }
        public List<int> TaskIds { get; }
        public int MaxNumberOfTasks { get; }
        public int MaxTimeForPlan { get; }
        public int LocationId { get; }
        public int SupervisorId { get; }
        public int AssigneeId { get; }
    }

    public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand>
    {
        public Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}