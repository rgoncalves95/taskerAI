using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaskerAI.Domain.Exceptions;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class TaskType : BaseEntity
    {
        private const string NameValidationMessage = "A task type name must be defined.";
        private const string CostDurationValidationMessage = "A cost or duration must be defined for a task type";

        internal static TaskType Create(string name, double? cost, int? duration, int? id = null) => new TaskType(name, cost, duration, id);

        internal static TaskType Create(string name, double? cost) => new TaskType(name, cost, null);

        internal static TaskType Create(string name, int? duration) => new TaskType(name, null, duration);

        internal static TaskType Create(int id) => new TaskType(id);

        private TaskType(string name, double? cost, int? duration, int? id = null)
        {
            this.Name = name;
            this.Cost = cost;
            this.Duration = duration;
            this.Id = id;

            IntegrityCheck();
        }

        private TaskType(int id) => base.Id = id;

        public string Name { get; private set; }
        public double? Cost { get; private set; }
        public int? Duration { get; private set; }
        //public IDictionary<string, string> Properties { get; set; }

        protected override void IntegrityCheck()
        {
            var integrityIssues = new List<string>();

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                integrityIssues.Add(NameValidationMessage);
            }

            if (!this.Cost.HasValue && !this.Duration.HasValue)
            {
                integrityIssues.Add(CostDurationValidationMessage);
            }

            if (integrityIssues.Count > 0)
            {
                throw new EntityIntegrityException(nameof(Task), integrityIssues);
            }
        }
    }
}