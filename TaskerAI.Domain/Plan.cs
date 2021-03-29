namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Domain.Entities;

    public class Plan : BaseEntity
    {
        private List<TaskRoute> taskRoutes;

        internal static Plan Create(IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date) => new Plan(taskRoutes, date);

        internal static Plan Create(int id, IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date) => new Plan(id, taskRoutes, date);

        private Plan(IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date)
        {
            this.Date = date;
            this.Status = PlanWorkflowState.Draft;
            this.taskRoutes = new List<TaskRoute>(taskRoutes);
        }

        private Plan(int id, IEnumerable<TaskRoute> taskRoutes, DateTimeOffset date) : this(taskRoutes, date) => this.Id = id;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Assignee Accountable { get; private set; }
        public Admin Responsible { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public PlanWorkflowState Status { get; private set; }
        public double EstimatedExecutionTime => this.TaskRoutes.Sum(t => t.RouteExecutionTimeInSeconds);

        public double EstimatedExecutionDistance => this.TaskRoutes.Sum(t => t.Distance);
        public IReadOnlyCollection<TaskRoute> TaskRoutes => this.taskRoutes.AsReadOnly();

        internal void ReorderTasks(IEnumerable<TaskRoute> taskRoutes) => this.taskRoutes = new List<TaskRoute>(taskRoutes);

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
            this.Accountable = user;
            this.Status = PlanWorkflowState.Approved;
        }

        internal List<Assignee> GetAvailableAssignees()
        {
            var result = new List<Assignee>();

            return result;

        }

        internal Plan AddRoute(TaskRoute route)
        {

            this.taskRoutes.Add(route);

            return this;
        }

        internal Plan Clone() => (Plan)MemberwiseClone();
        protected override void IntegrityCheck() => throw new NotImplementedException();
    }
}
