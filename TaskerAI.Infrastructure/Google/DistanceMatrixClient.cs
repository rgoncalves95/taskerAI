namespace TaskerAI.Infrastructure.Google
{
    using System.Collections.Generic;
    using TaskerAI.Domain;

    public class DistanceMatrixClient : ITaskRouteRepository
    {
        public List<TaskRoute> GetRoutes(List<Task> from, List<Task> to) =>
            //DistanceMatrixResult googleResponse = client.Get(from.Locations, to.Locations);
            //return TaskRoute.Create(googleResponse.A, googleResponse.B, googleResponse.C);

            null;
    }
}
