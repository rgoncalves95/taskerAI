namespace TaskerAI.Infrastructure
{
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Dto;

    public interface IGeolocationProvider
    {
        Task<GeolocationDto> GetGeolocationAsync(string searchTerm);
    }
}
