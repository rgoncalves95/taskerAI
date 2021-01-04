﻿namespace TaskerAI.Api.Models.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Infrastructure;

    public class TaskModelMapper : IMapper<Domain.Task, TaskModel>
    {
        public void Map(Domain.Task from, TaskModel to)
        {
            to.Name = from.Name;
            to.TypeId = from.Type?.Id ?? -1; //TODO remove this after acessing type
            to.LocationId = from.Location?.Id ?? -1; //TODO remove this after acessing location
            to.Date = from.Date;
            to.DueDate = from.DueDate;
            to.DurationInSeconds = from.DurationInSeconds;
            to.Notes = from.Notes;
        }
        public TaskModel Map(Domain.Task from)
        {
            var to = new TaskModel();
            Map(from, to);
            return to;
        }
        public void Map(IEnumerable<Domain.Task> from, IEnumerable<TaskModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<TaskModel> Map(IEnumerable<Domain.Task> from) => from.Select(f => Map(f)).ToArray();
    }
}