namespace TaskerAI.Infrastructure.Dto.Enrichers
{
    public class GeolocationEnricher : IEnricher<LocationDto>
    {
        private readonly IGeolocationProvider geolocationProvider;

        public GeolocationEnricher(IGeolocationProvider geolocationProvider) => this.geolocationProvider = geolocationProvider;

        public void Enrich(LocationDto dto)
        {
            dto.Latitude = "DUMMY_LAT";
            dto.Longitude = "DUMMY_LON";
        }
    }
}
