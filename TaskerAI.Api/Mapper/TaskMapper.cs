namespace TaskerAI.Api.Mapper
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Infrastructure;

    public class TaskMapper : IMapper<Domain.Task, TaskModel>
    {
        public void Map(Domain.Task from, TaskModel to) => throw new System.NotImplementedException();
        public TaskModel Map(Domain.Task from) => throw new System.NotImplementedException();
        public void Map(IEnumerable<Domain.Task> from, IEnumerable<TaskModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<TaskModel> Map(IEnumerable<Domain.Task> from) => from.Select(f => Map(f)).ToArray();
    }
}
