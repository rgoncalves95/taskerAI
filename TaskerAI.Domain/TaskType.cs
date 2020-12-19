using System.Collections.Generic;

namespace TaskerAI.Domain
{
    public class TaskType
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public Location Location { get; set; }
        public int DurationInSeconds { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }

}