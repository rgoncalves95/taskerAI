namespace TaskerAI.Domain
{
    using TaskerAI.Domain;

    public interface ITaskRepository
    {
        Task GetTask(int id);
        Task CreateTask(Task task);
        Task GetTaskByUser(int UserId);
    }
}
