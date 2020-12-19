using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    internal class Plan : IPlan
    {
        internal static Plan Create(string name)
        {
            var plan = new Plan(name);

            return plan;
        }

        internal static Plan Create(int id, string name)
        {
            var plan = new Plan(name);

            return plan;
        }

        internal void ReorderTasks(List<Task> tasks)
        {
            this.Tasks = tasks;
        }

        internal Plan(string name)
        {
            this.Name = name;
        }

        internal Plan(int id, string name) : this(name)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Task> Tasks { get; private set; }
        public User Accountable { get; private set; }
        public User Responsible { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public int Status { get; private set; }

        internal void Recalc()
        {

        }

        internal void CancelTasks()
        {

        }

        internal void Finish()
        {

        }
    }
}
