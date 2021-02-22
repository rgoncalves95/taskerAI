namespace TaskerAI.Infrastructure
{
    using TaskerAI.Infrastructure.Dto;

    public interface IGeolocationProvider
    {
        GeolocationDto GetGeolocation(string searchTerm);
    }
}
