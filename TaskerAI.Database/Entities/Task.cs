namespace TaskerAI.Database.Entities
{
    using System;
    using Dapper.Contrib.Extensions;

    public class Task
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int TaskTypeId { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset? FinishDate { get; set; }
        public int DurationInSeconds { get; set; }
        public string Notes { get; set; }
        [Write(false)]
        public virtual TaskType TaskType { get; set; }
        [Write(false)]
        public virtual Location Location { get; set; }
    }
}
