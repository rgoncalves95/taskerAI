using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Plan
    {
        internal static Plan Create(IList<TaskRoute> tasks, DateTimeOffset date) => new Plan(tasks, date);

        private Plan(IList<TaskRoute> tasks, DateTimeOffset date)
        {
            TaskRoutes = tasks;
            Date = date;
            Status = PlanWorkflowState.Draft;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IList<TaskRoute> TaskRoutes { get; private set; }
        public Assignee Accountable { get; private set; }
        public Admin Responsible { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public PlanWorkflowState Status { get; private set; }
        public decimal EstimatedExecutionTime => TaskRoutes.Sum(t => t.RouteExecutionTimeInSeconds);

        internal void ReorderTasks(List<TaskRoute> tasks) => TaskRoutes = tasks;

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
