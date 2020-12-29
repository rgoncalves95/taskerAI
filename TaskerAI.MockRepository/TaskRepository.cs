namespace TaskerAI.MockRepository
{
    using System;
    using TaskerAI.Domain;

    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(Task task) => Task.Create(1, task.Name, task.Status, task.Type, task.Location, task.Date, task.DueDate, task.FinishDate, 0, task.Position, task.Notes);
        public Task GetTask(int id) => FakerFactory.CreateTask(id);
        public Task GetTaskByUser(int UserId) => throw new NotImplementedException();
    }
}
