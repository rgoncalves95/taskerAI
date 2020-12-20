namespace TaskerAI.Dapper
{
    using System;
    using TaskerAI.Domain;

    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(Task task) => throw new NotImplementedException();
        public Task GetTask(int id) => throw new NotImplementedException();
        public Task GetTaskByUser(int UserId) => throw new NotImplementedException();
    }
}
