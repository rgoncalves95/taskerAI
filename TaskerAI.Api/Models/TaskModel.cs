namespace TaskerAI.Api.Models
{
    using System;

    public class TaskModel
    {
        public int? Id { get; internal set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DueDate { get; set; }
        //public DateTimeOffset FinishDate { get; set; }
        public int DurationInSeconds { get; set; }
        public string Notes { get; set; }

        //public List<TaskMetadataModel> Metadata { get; set; }
    }
}