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

        public DateTimeOffset EstimatedStartDate { get; private set; }

        public DateTimeOffset EstimatedEndDate { get; private set; }

        public DateTimeOffset Date { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset FinishDate { get; private set; }
        public int Duration { get; private set; }
        public int Position { get; private set; }
        public string Notes { get; private set; }

        internal Task(string name, int status, TaskType type, Location location, DateTimeOffset date, DateTimeOffset dueDate, int duration, int position, string notes)
        {
            Name = name;
            Status = status;
            Type = type;
            Location = location;
            Date = date;
            DueDate = dueDate;
            Duration = duration;
            Position = position;
            Notes = notes;
        }

        internal Task(int id, string name, int status, TaskType type, Location location, DateTimeOffset estimatedStartDate, DateTimeOffset estimatedEndDate, DateTimeOffset date, DateTimeOffset dueDate, DateTimeOffset finishDate, int duration, int position, string notes)
        {
            Id = id;
            Name = name;
            Status = status;
            Type = type;
            Location = location;
            EstimatedStartDate = estimatedStartDate;
            EstimatedEndDate = estimatedEndDate;
            Date = date;
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


        internal void Estimate(DateTimeOffset estimatedStartDate)
        {

            this.EstimatedStartDate = estimatedStartDate;

            this.EstimatedEndDate = estimatedStartDate.AddSeconds(this.Duration);

        }


        internal void ChangePosition(int position) => Position = position;
    }
}