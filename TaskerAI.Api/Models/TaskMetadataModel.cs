namespace TaskerAI.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TaskMetadataModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Constraint { get; set; }
        public bool Required { get; set; }
    }
}
