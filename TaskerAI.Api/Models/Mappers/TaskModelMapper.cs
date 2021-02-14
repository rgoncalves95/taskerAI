namespace TaskerAI.Api.Models.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    public class TaskModelMapper : IMapper<Task, TaskModel>
    {
        public void Map(Task from, TaskModel to)
        {
            to.Id = from.Id ?? 0;
            to.Name = from.Name;
            to.TypeId = from.Type?.Id ?? 0;
            to.LocationId = from.Location?.Id ?? 0;
            to.Date = from.Date;
            to.DueDate = from.DueDate;
            to.DurationInSeconds = from.DurationInSeconds;
            to.Notes = from.Notes;
        }
        public TaskModel Map(Task from)
        {
            var to = new TaskModel();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<Task> from, IEnumerable<TaskModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<TaskModel> Map(IEnumerable<Task> from) => from.Select(f => Map(f)).ToArray();
    }
}
