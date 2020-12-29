using System;
using System.Collections.Generic;
using System.Linq;
using TaskerAI.Domain;

namespace TaskerAI.Application
{
    class Algoritmo : IAlgoritmo
    {
        private readonly ITimeDistance timeDistance;

        public Algoritmo(ITimeDistance timeDistance)
        {
            this.timeDistance = timeDistance;
        }

        public Domain.Plan CreatePlan(List<Task> tasks, int maxTasks, int maxTimeInSeconds, Location location, int radius, DateTime planDateTime)
        {

            var plansList = new List<Plan>();
            int planTotalTime = 0;
            decimal planTotalDistance = 0;

            //get distance for all taks possible
            var taskDistancesList = new List<TaskDistance>();


            var resultTasksList = new List<Task>();
            var planTasksList = new List<Task>(tasks);

            var firstTask = planTasksList.FindAll(t => t.Date.Year == planDateTime.Year && t.Date.Month == planDateTime.Month && t.Date.Day == planDateTime.Day).OrderBy(t => t.DueDate).First<Task>();

            firstTask.Estimate(planDateTime);
            planTotalTime += firstTask.Duration;

            resultTasksList.Add(firstTask);
            planTasksList.Remove(firstTask);

            var thisTask = firstTask;

            while (planTasksList.Count > 0 || resultTasksList.Count < maxTasks || planTotalTime < maxTimeInSeconds)
            {
                var nextTask = new Task();
                var taskRoute = new TaskDistance();

                if (taskDistancesList.FindAll(td => td.TaskFromId == thisTask.Id && planTasksList.Find(pt => pt.Id == td.TaskToId).DueDate >= thisTask.EstimatedEndDate.AddSeconds(td.TimeInSeconds).AddSeconds(thisTask.Duration)).Count > 0)
                {
                    taskRoute = taskDistancesList.FindAll(td => td.TaskFromId == thisTask.Id && planTasksList.Find(pt => pt.Id == td.TaskToId).DueDate >= thisTask.EstimatedEndDate.AddSeconds(td.TimeInSeconds).AddSeconds(thisTask.Type.DurationInSeconds)).OrderBy(td => td.TimeInSeconds).First<TaskDistance>();
                    nextTask = planTasksList.Find(t => t.Id == taskRoute.TaskToId);
                }
                else
                {
                    taskRoute = taskDistancesList.FindAll(td => td.TaskFromId == thisTask.Id).OrderBy(td => td.TimeInSeconds).First<TaskDistance>();
                    nextTask = planTasksList.Find(t => t.Id == taskRoute.TaskToId);
                }
                nextTask.Estimate(thisTask.EstimatedEndDate.AddSeconds(taskRoute.TimeInSeconds));
                thisTask = nextTask;

                planTotalTime += thisTask.Duration + taskRoute.TimeInSeconds;
                planTotalDistance += taskRoute.Distance;

                resultTasksList.Add(nextTask);
                planTasksList.Remove(nextTask);


            }




            return new Domain.Plan("", resultTasksList, planDateTime, planTotalTime);
        }
    }

    public class TaskDistance
    {
        public int TaskFromId { get; private set; }

        public int TaskToId { get; private set; }

        public decimal Distance { get; private set; }

        public int TimeInSeconds { get; private set; }

        public TaskDistance(int taskFromId, int taskToId, decimal distance, int timeInSeconds)
        {
            TaskFromId = taskFromId;
            TaskToId = taskToId;
            Distance = distance;
            TimeInSeconds = timeInSeconds;
        }

        public TaskDistance()
        {
        }
    }


}
