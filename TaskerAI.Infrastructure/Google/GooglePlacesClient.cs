namespace TaskerAI.Infrastructure.Google
{
    using System;
    using TaskerAI.Infrastructure.Dto;

    public class GooglePlacesClient : IGeolocationProvider
    {
        public GeolocationDto GetGeolocation(string searchTerm) => throw new NotImplementedException();
    }
}
