namespace TaskerAI.Api.Models.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    public class TaskTypeModelMapper : IMapper<TaskType, TaskTypeModel>
    {
        public void Map(TaskType from, TaskTypeModel to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Cost = from.Cost;
            to.Duration = from.Duration;
        }
        public TaskTypeModel Map(TaskType from)
        {
            var to = new TaskTypeModel();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<TaskType> from, IEnumerable<TaskTypeModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<TaskTypeModel> Map(IEnumerable<TaskType> from) => from.Select(f => Map(f)).ToArray();
    }
}
