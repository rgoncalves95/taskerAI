namespace TaskerAI.Api.Mapper
{
    using TaskerAI.Api.Models;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;

    public class TasksMapper : IMapper<Domain.Task, TaskModel>
    {
        public void Map(Domain.Task from, TaskModel to) => throw new System.NotImplementedException();
        public TaskModel Map(Domain.Task from) => throw new System.NotImplementedException();
    }
}
