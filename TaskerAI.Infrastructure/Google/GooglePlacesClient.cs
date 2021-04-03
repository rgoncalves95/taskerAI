namespace TaskerAI.Infrastructure.Google
{
    using System;
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Dto;

    public class GooglePlacesClient : IGeolocationProvider
    {
        public Task<GeolocationDto> GetGeolocationAsync(string searchTerm) => throw new NotImplementedException();
    }
}
