﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
[assembly: InternalsVisibleTo("TaskerAI.Api.Tests")]
namespace TaskerAI.Domain
{
    public class Plan
    {
        private List<TaskRoute> taskRoutes;

        internal static Plan Create(IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date)
        {
            return new Plan(taskRoutes, date);
        }

        internal static Plan Create(int id, IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date)
        {
            return new Plan(id, taskRoutes, date);
        }

        private Plan(IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date)
        {
            this.Date = date;
            this.Status = PlanWorkflowState.Draft;
            this.taskRoutes = new List<TaskRoute>(taskRoutes);
        }

        private Plan(int id, IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date) : this(taskRoutes, date)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Assignee Accountable { get; private set; }
        public Admin Responsible { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public PlanWorkflowState Status { get; private set; }
        public decimal EstimatedExecutionTime => TaskRoutes.Sum(t => t.RouteExecutionTimeInSeconds);
        public IReadOnlyCollection<TaskRoute> TaskRoutes => this.taskRoutes.AsReadOnly();

        internal void ReorderTasks(IEnumerable<TaskRoute> taskRoutes)
        {
            this.taskRoutes = new List<TaskRoute>(taskRoutes);
        }

        internal void Recalc()
        {

        }

        internal void RemoveTasks()
        {

        }

        internal void Finish()
        {

        }

        internal void Assign(Assignee user)
        {
            Accountable = user;
            Status = PlanWorkflowState.Approved;
        }

        internal List<Assignee> GetAvailableAssignees()
        {
            var result = new List<Assignee>();

            return result;

        }
    }
}
