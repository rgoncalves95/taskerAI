namespace TaskerAI.Application
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain = TaskerAI.Domain;
    using Builder = PlanBuilder;
    using System;
    using System.Linq;

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
            var routeResults = builder.Build(tasks, routes);

            var result = new List<PlanResult>();


            foreach (var routeResult in routeResults)
            {
                var tasksPlanned = new List<TaskPlanned>();
                var task = tasks.First(p => p.Id == routeResult.StartTask);

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
            Tasks = tasks;
            TotalDistance = distance;
        }

        public List<TaskPlanned> Tasks { get; } = new List<TaskPlanned>();

        public int TotalDistance { get; }
    }

    public class TaskPlanned
    {
        public TaskPlanned(string displayName, int order, DateTime dueDate, DateTime arrivalDate, double latitude, double longitude)
        {
            DisplayName = displayName;
            Order = order;
            DueDate = dueDate;
            ArrivalDate = arrivalDate;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string DisplayName { get; }
        public int Order { get; }
        public DateTime DueDate { get; }
        public DateTime ArrivalDate { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
