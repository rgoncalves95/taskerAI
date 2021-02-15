namespace TaskerAI.Api.Models.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    public class TaskModelMapper : IMapper<Task, TaskModel>
    {
        private readonly IMapper<Location, LocationModel> locationMapper;

        public TaskModelMapper(IMapper<Location, LocationModel> locationMapper) => this.locationMapper = locationMapper;

        public void Map(Task from, TaskModel to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.TypeId = from.Type.Id.Value;
            to.Location = this.locationMapper.Map(from.Location);
            to.Date = from.Date;
            to.DueDate = from.DueDate;
            to.Duration = from.DurationInSeconds;
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
