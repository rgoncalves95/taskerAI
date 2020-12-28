using TaskerAI.Persistence;

namespace TaskerAI.Application
{
    public interface ITimeDistance
    {
        decimal GetTime((string lat, string lon) A, (string lat, string lon) B);
    }

    public interface IGMapsClient
    {

    }

    public class GMapsTimeDistance : ITimeDistance
    {
        private readonly IGMapsClient gmapsClient;

        public GMapsTimeDistance(IGMapsClient gmapsClient)
        {
            this.gmapsClient = gmapsClient;
        }

        public decimal GetTime((string lat, string lon) A, (string lat, string lon) B) => throw new System.NotImplementedException();
    }

    public class DbTimeDistance : ITimeDistance
    {
        private readonly ITimeLocationRepository repo;

        public DbTimeDistance(ITimeLocationRepository repo)
        {
            this.repo = repo;
        }

        public decimal GetTime((string lat, string lon) A, (string lat, string lon) B) => throw new System.NotImplementedException();
    }
}