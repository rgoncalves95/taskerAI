using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Task
    {
        internal static Task Create(int id, string name, int status, TaskType type, Location location, DateTimeOffset date, DateTimeOffset dueDate, DateTimeOffset finishDate, int durationInSeconds, int position, string notes)
        {
            return new Task(id, name, status, type, location, date, dueDate, finishDate, durationInSeconds, position, notes);
        }

        private Task(int id, string name, int status, TaskType type, Location location, DateTimeOffset date, DateTimeOffset dueDate, DateTimeOffset finishDate, int durationInSeconds, int position, string notes)
        {
            Id = id;
            Name = name;
            Status = status;
            Type = type;
            Location = location;
            Date = date;
            DueDate = dueDate;
            FinishDate = finishDate;
            DurationInSeconds = durationInSeconds;
            Position = position;
            Notes = notes;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int Status { get; private set; }
        public TaskType Type { get; private set; }
        public Location Location { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset FinishDate { get; private set; }
        public int DurationInSeconds { get; private set; }
        public int Position { get; private set; }
        public string Notes { get; private set; }

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