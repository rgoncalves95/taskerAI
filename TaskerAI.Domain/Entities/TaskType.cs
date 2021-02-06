using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class TaskType : BaseEntity
    {
        internal static TaskType Create(string name, double cost, int durationInSeconds, int? id = null) => new TaskType(name, cost, durationInSeconds, id);

        internal static TaskType Create(int id) => new TaskType(id);

        private TaskType(string name, double cost, int durationInSeconds, int? id = null)
        {
            this.Name = name;
            this.Cost = cost;
            this.DurationInSeconds = durationInSeconds;
            this.Id = id;
        }

        private TaskType(int id) => base.Id = id;

        public string Name { get; private set; }
        public double Cost { get; private set; }
        public int DurationInSeconds { get; private set; }
        //public IDictionary<string, string> Properties { get; set; }

        protected override void IntegrityCheck() => throw new System.NotImplementedException();
    }
}