namespace TaskerAI.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Builder = PlanBuilder;
    using Domain = TaskerAI.Domain;

    public class CreatePlanCommand : IRequest<List<PlanResult>>
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

    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, List<PlanResult>>
    {
        private readonly Domain.IPlanRepository repo;

        public CreatePlanCommandHandler(Domain.IPlanRepository repo) => this.repo = repo;

        public async Task<List<PlanResult>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var demoData = new Builder.DemoData();
            List<Builder.Task> tasks = demoData.GetTasks();
            Dictionary<(Guid, Guid), Builder.Route> routes = demoData.GetRoutes(tasks);

            var builder = new Builder.Builder();
            List<Builder.RouteResult> routeResults = builder.Build(tasks, routes);

            var result = new List<PlanResult>();


            foreach (Builder.RouteResult routeResult in routeResults)
            {
                var tasksPlanned = new List<TaskPlanned>();
                Builder.Task task = tasks.First(p => p.Id == routeResult.StartTask);

                var startTask = new TaskPlanned(task.Display, 0, task.DueDate, task.DueDate, task.Latitude, task.Longitude);
                tasksPlanned.Add(startTask);
                for (int i = 0; i < routeResult.TaskResults.Count; i++)
                {
                    task = tasks.First(p => p.Id == routeResult.TaskResults[i].Id);

                    var taskPlanned = new TaskPlanned(task.Display, i + 1, task.DueDate, routeResult.TaskResults[i].EstimatedArrival, task.Latitude, task.Longitude);
                    tasksPlanned.Add(taskPlanned);
                }
                var planResult = new PlanResult(tasksPlanned, routeResult.TotalDistance);
                result.Add(planResult);
            }

            return result;
        }

    }

    public class PlanResult
    {
        public PlanResult(List<TaskPlanned> tasks, int distance)
        {
            this.Tasks = tasks;
            this.TotalDistance = distance;
        }

        public List<TaskPlanned> Tasks { get; } = new List<TaskPlanned>();

        public int TotalDistance { get; }
    }

    public class TaskPlanned
    {
        public TaskPlanned(string displayName, int order, DateTime dueDate, DateTime arrivalDate, double latitude, double longitude)
        {
            this.DisplayName = displayName;
            this.Order = order;
            this.DueDate = dueDate;
            this.ArrivalDate = arrivalDate;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public string DisplayName { get; }
        public int Order { get; }
        public DateTime DueDate { get; }
        public DateTime ArrivalDate { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
