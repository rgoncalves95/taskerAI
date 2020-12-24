using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Task
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Status { get; private set; }
        public TaskType Type { get; private set; }
        public Location Location { get; private set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset FinishDate { get; set; }
        public int Duration { get; set; }
        public int Position { get; set; }
        public string Notes { get; set; }

        internal Task(int id, string name, int status, TaskType type, Location location, DateTimeOffset dueDate, DateTimeOffset finishDate, int duration, int position, string notes)
        {
            Id = id;
            Name = name;
            Status = status;
            Type = type;
            Location = location;
            DueDate = dueDate;
            FinishDate = finishDate;
            Duration = duration;
            Position = position;
            Notes = notes;
        }

        public Task()
        {
        }

        internal void Cancel()
        {

        }

        internal void Start()
        {

        }

        internal void Finish()
        {

        }

        internal void ChangePosition(int position) => Position = position;
    }
}