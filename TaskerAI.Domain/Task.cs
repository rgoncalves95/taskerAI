using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Task
    {
        internal static Task Create
        (
            string name,
            TaskType type,
            Location location,
            DateTimeOffset date,
            DateTimeOffset dueDate,
            int durationInSeconds,
            string notes,
            int? id = null,
            int? status = null,
            DateTimeOffset? finishDate = null
        )
        {
            return new Task(name, type, location, date, dueDate, durationInSeconds, notes, id, status, finishDate);
        }

        private Task
        (
            string name,
            TaskType type,
            Location location,
            DateTimeOffset date,
            DateTimeOffset dueDate,
            int durationInSeconds,
            string notes,
            int? id,
            int? status,
            DateTimeOffset? finishDate
        )
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
            Notes = notes;
        }

        public int? Id { get; private set; }
        public string Name { get; set; }
        public int? Status { get; private set; }
        public TaskType Type { get; private set; }
        public Location Location { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset? FinishDate { get; private set; }
        public int DurationInSeconds { get; private set; }
        public string Notes { get; private set; }

        public void EndTask()
        {
            this.FinishDate = DateTimeOffset.UtcNow;
        }
    }
}