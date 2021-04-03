namespace TaskerAI.Database.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Task
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int IdType { get; set; }
        public int IdLocation { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset? FinishDate { get; set; }
        public int DurationInSeconds { get; set; }
        public string Notes { get; set; }

        public bool IsNew => this.Id == default(int);


    }

}
