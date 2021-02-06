using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaskerAI.Domain.Exceptions;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Task : BaseEntity
    {
        private const string NameValidationMessage = "A task name must be defined.";
        private const string TypeValidationMessage = "A task must have an predefined type.";
        private const string LocationValidationMessage = "A task must have a predefined location.";
        private const string DateValidationMessage = "A task execution date must be specified.";
        private const string DueDateValidationMessage = "A task due date must be specified.";
        private const string DatesMismatchValidationMessage = "Due date and execution date mismatch. Due date should be after execution date.";
        private const string DurationValidationMessage = "A task duration must be specified.";

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
            TaskStatus? status = null,
            DateTimeOffset? finishDate = null
        ) => new Task(name, type, location, date, dueDate, durationInSeconds, notes, id, status, finishDate);

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
            TaskStatus? status,
            DateTimeOffset? finishDate
        )
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
            this.Type = type;
            this.Location = location;
            this.Date = date;
            this.DueDate = dueDate;
            this.FinishDate = finishDate;
            this.DurationInSeconds = durationInSeconds;
            this.Notes = notes;

            IntegrityCheck();
        }

        public string Name { get; set; }
        public TaskStatus? Status { get; private set; }
        public TaskType Type { get; private set; }
        public Location Location { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset? FinishDate { get; private set; }
        public int DurationInSeconds { get; private set; }
        public string Notes { get; private set; }

        public void EndTask() => this.FinishDate = DateTimeOffset.UtcNow;

        protected override void IntegrityCheck()
        {
            var integrityIssues = new List<string>();

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                integrityIssues.Add(NameValidationMessage);
            }

            if (this.Type is null)
            {
                integrityIssues.Add(TypeValidationMessage);
            }

            if (this.Location is null)
            {
                integrityIssues.Add(LocationValidationMessage);
            }

            if (this.Date == default)
            {
                integrityIssues.Add(DateValidationMessage);
            }

            if (this.DueDate == default)
            {
                integrityIssues.Add(DueDateValidationMessage);
            }

            if (this.DueDate.Date < this.Date.Date)
            {
                integrityIssues.Add(DatesMismatchValidationMessage);
            }

            if (this.DurationInSeconds == default)
            {
                integrityIssues.Add(DurationValidationMessage);
            }

            if (integrityIssues.Count > 0)
            {
                throw new EntityIntegrityException(nameof(Task), integrityIssues);
            }
        }
    }
}