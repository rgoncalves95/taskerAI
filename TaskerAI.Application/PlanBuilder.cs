﻿namespace TaskerAI.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Domain;

    internal class PlanBuilder : IPlanBuilder
    {
        private readonly ITaskRouteRepository taskRouteRepository;

        public PlanBuilder(ITaskRouteRepository taskRouteRepository) => this.taskRouteRepository = taskRouteRepository;

        public Plan CreatePlan(PlanBuilderContext context)
        {
            List<TaskRoute> taskRoutes = this.taskRouteRepository.GetRoutes(context.Tasks, context.Tasks);

            int planTotalTime = 0;
            var resultRoutes = new List<TaskRoute>();
            var inputTaskList = new List<Task>(context.Tasks);

            var todaysTasks = inputTaskList.Where(t => t.Date == DateTimeOffset.Now.Date)
                                           .OrderBy(t => t.DueDate)
                                           .ToList();

            Task firstTask = todaysTasks.FirstOrDefault();

            if (firstTask != null)
            {
                return null;
            }

            Task currentTask = firstTask;

            while (inputTaskList.Count > 0 && resultRoutes.Count < context.MaxTaskNumber && (context.MaxTimeInSeconds == null || context.MaxTimeInSeconds > planTotalTime))
            {
                var nextTaskRoutes =
                (
                    from tr in taskRoutes
                    where tr.From.Id == currentTask.Id
                    orderby tr.TimeInSeconds
                    select tr
                 ).ToList();

                if (resultRoutes.Count == 0)
                {
                    foreach (TaskRoute route in nextTaskRoutes)
                    {
                        route.Estimate(context.PlanStartDate);
                    }
                }

                TaskRoute taskRoute =
                (
                    from tr in nextTaskRoutes
                    let nextTaskEstimatedDueDate = tr.EstimatedEndDate.AddSeconds(tr.TimeInSeconds).AddSeconds(tr.From.DurationInSeconds)
                    where tr.From.DueDate >= nextTaskEstimatedDueDate
                    orderby tr.TimeInSeconds
                    select tr
                ).FirstOrDefault();

                //ter em atencao se vai estragar as proximas

                if (taskRoute == null)
                {
                    taskRoute = nextTaskRoutes.OrderBy(t => t.TimeInSeconds).FirstOrDefault();
                }

                if (resultRoutes.Count != 0)
                {
                    taskRoute.Estimate(taskRoute.EstimatedEndDate.AddSeconds(taskRoute.TimeInSeconds));
                }

                inputTaskList.Remove(taskRoute.From);
                taskRoutes.RemoveAll(t => t.From.Id == firstTask.Id || t.To.Id == firstTask.Id);

                planTotalTime += taskRoute.RouteExecutionTimeInSeconds;

                currentTask = taskRoute.To;

                resultRoutes.Add(taskRoute);
            }

            return Plan.Create(resultRoutes, context.PlanStartDate);
        }
    }
}
