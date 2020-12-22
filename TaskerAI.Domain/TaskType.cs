﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Location Location { get; set; }
        public int DurationInSeconds { get; set; }
        public IDictionary<string, string> Properties { get; set; }

        internal TaskType(int id, string name, double cost, Location location, int durationInSeconds, IDictionary<string, string> properties)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Location = location;
            this.DurationInSeconds = durationInSeconds;
            this.Properties = properties;


        }
    }

}