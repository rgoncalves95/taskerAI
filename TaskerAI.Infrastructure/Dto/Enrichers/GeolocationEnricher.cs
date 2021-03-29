namespace TaskerAI.Infrastructure.Dto.Enrichers
{
    using System.Text;
    using System.Threading.Tasks;

    public class GeolocationEnricher : IEnricher<LocationDto>
    {
        private readonly IGeolocationProvider geolocationProvider;

        public GeolocationEnricher(IGeolocationProvider geolocationProvider) => this.geolocationProvider = geolocationProvider;

        public async Task EnrichAsync(LocationDto dto)
        {
            GeolocationDto geolocation = await this.geolocationProvider.GetGeolocationAsync(BuidSearchTerm(dto));

            dto.Longitude = geolocation.Longitude;
            dto.Latitude = geolocation.Latitude;
        }

        private string BuidSearchTerm(LocationDto dto)
        {
            const string SPACE = " ";

            var builder = new StringBuilder();

            builder.Append($"{dto.Street} {dto.Door}");

            if (!string.IsNullOrWhiteSpace(dto.Floor))
            {
                builder.Append($"{SPACE} {dto.Floor}");
            }

            builder.Append($", {dto.ZipCode}");

            if (!string.IsNullOrWhiteSpace(dto.City))
            {
                builder.Append($"{SPACE} {dto.City}");
            }

            if (!string.IsNullOrWhiteSpace(dto.Country))
            {
                builder.Append($", {dto.Country}");
            }

            return builder.ToString();
        }
    }
}
