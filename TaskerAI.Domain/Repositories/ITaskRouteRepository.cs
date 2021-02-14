namespace TaskerAI.Domain
{
    using System.Collections.Generic;
    using TaskerAI.Domain.Entities;

    public interface ITaskRouteRepository
    {
        List<TaskRoute> GetRoutes(List<Task> from, List<Task> to);
    }
}
