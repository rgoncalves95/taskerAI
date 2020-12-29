namespace TaskerAI.Domain
{
    using System.Collections.Generic;

    public interface ITaskRouteRepository
    {
        List<TaskRoute> GetRoutes(List<Task> from, List<Task> to);
    }
}
