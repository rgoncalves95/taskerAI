using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaskerAI.Domain
{
    public class Plan
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IList<Task> Tasks { get; private set; }
        public Assignee Accountable { get; private set; }
        public Admin Responsible { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public PlanWorkflowState Status { get; private set; }

        public int TotalDurationInMins { get; private set; }

        internal Plan(string name) => Name = name;

        internal Plan(int id, string name) : this(name) => Id = id;

        internal static Plan Create(string name)
        {
            var plan = new Plan(name);

            return plan;
        }

        internal static Plan Create(int id, string name)
        {
            var plan = new Plan(id, name);

            return plan;
        }

        internal void ReorderTasks(List<Task> tasks) => Tasks = tasks;

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
    }
}
