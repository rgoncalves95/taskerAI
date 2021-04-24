namespace TaskerAI.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Infrastructure;
    using TaskerAI.Infrastructure.Dto;
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
        private readonly Domain.IPlanRepository _repo;
        private readonly Domain.ITaskRepository _taskRepo;
        private readonly IMatrixRouteProvider _matrixRouteProvider;

        public CreatePlanCommandHandler(Domain.IPlanRepository repo, Domain.ITaskRepository taskRepo, IMatrixRouteProvider matrixRouteProvider)
        {
            _repo = repo;
            _taskRepo = taskRepo;
            _matrixRouteProvider = matrixRouteProvider;
        }

        private Dictionary<(int, int), Builder.Route> CreateRoutes(IList<Domain.Entities.Task> tasks, MatrixRouteDto matrixRoutes)
        {
            var result = new Dictionary<(int, int), Builder.Route>();
            var tasksLength = tasks.Count;
            for (int i = 0; i < tasksLength; i++)
            {
                for (int j = 0; j < tasksLength; j++)
                {
                    if (i == j) 
                    {
                        continue;
                    }

                    result.Add((tasks[i].Id.Value, tasks[j].Id.Value), new Builder.Route()
                    {
                        From = tasks[i].Id.Value,
                        To = tasks[j].Id.Value,
                        Distance = matrixRoutes.Distances[i][j],
                        TimeInSeconds = matrixRoutes.Durations[i][j]
                    });;
                }
            }

            return result;
        }

        public async Task<List<PlanResult>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var demoData = new Builder.DemoData();

            var tasks = (await _taskRepo.GetAsync(request.TaskIds)).ToList();

            var coordinates = tasks.Select(t => new float[] { float.Parse(t.Location.Longitude), float.Parse(t.Location.Latitude) });

            var matrixRoutes = await _matrixRouteProvider.GetMatrixRoutes(coordinates.ToArray());


            Dictionary<(int, int), Builder.Route> routes = CreateRoutes(tasks, matrixRoutes);

            var builder = new Builder.Builder();
            List<Builder.RouteResult> routeResults = builder.Build(tasks, routes);

            var result = new List<PlanResult>();


            foreach (Builder.RouteResult routeResult in routeResults)
            {
                var tasksPlanned = new List<TaskPlanned>();
                Domain.Entities.Task task = tasks.First(p => p.Id.Value == routeResult.StartTask);

                var startTask = new TaskPlanned(task.Name, 0, task.DueDate, task.DueDate, float.Parse(task.Location.Latitude), float.Parse(task.Location.Longitude));
                tasksPlanned.Add(startTask);
                for (int i = 0; i < routeResult.TaskResults.Count; i++)
                {
                    task = tasks.First(p => p.Id == routeResult.TaskResults[i].Id);

                    var taskPlanned = new TaskPlanned(task.Name, i + 1, task.DueDate, routeResult.TaskResults[i].EstimatedArrival, float.Parse(task.Location.Latitude), float.Parse(task.Location.Longitude));
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
        public PlanResult(List<TaskPlanned> tasks, float distance)
        {
            this.Tasks = tasks;
            this.TotalDistance = distance;
        }

        public List<TaskPlanned> Tasks { get; } = new List<TaskPlanned>();

        public float TotalDistance { get; }
    }

    public class TaskPlanned
    {
        public TaskPlanned(string displayName, int order, DateTimeOffset dueDate, DateTimeOffset arrivalDate, double latitude, double longitude)
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
        public DateTimeOffset DueDate { get; }
        public DateTimeOffset ArrivalDate { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
