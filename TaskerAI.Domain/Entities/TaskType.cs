using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class TaskType : BaseEntity
    {
        internal static TaskType Create(string name, double cost, int durationInSeconds, int? id = null) => new TaskType(name, cost, durationInSeconds, id);

        internal static TaskType Create(int id) => new TaskType(id);
        protected override void IntegrityCheck() => throw new System.NotImplementedException();

        private TaskType(string name, double cost, int durationInSeconds, int? id = null)
        {
            this.Name = name;
            this.Cost = cost;
            this.DurationInSeconds = durationInSeconds;
            this.Id = id;
        }

        private TaskType(int id) => this.Id = id;

        public string Name { get; set; }
        public double Cost { get; set; }
        public int DurationInSeconds { get; set; }
        //public IDictionary<string, string> Properties { get; set; }
    }
}