namespace TaskerAI.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class TaskModel
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset FinishDate { get; set; }
        public int Duration { get; set; }
        public int Position { get; set; }
        public string Notes { get; set; }

        //public List<TaskMetadataModel> Metadata { get; set; }
    }
}