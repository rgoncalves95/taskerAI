namespace TaskerAI.MockRepository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(Task task) => new Task(1, task.Name, task.Status, task.Type, task.Location, task.DueDate, task.FinishDate, task.Duration, task.Position, task.Notes);
        public Task GetTask(int id) => FakerFactory.CreateTask(id);
        public Task GetTaskByUser(int UserId) => throw new NotImplementedException();
    }
}
