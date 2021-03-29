namespace TaskerAI.Infrastructure.MapBox
{
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Dto;

    public class SearchClient : IGeolocationProvider
    {
        private readonly MapBoxClient client;
        private readonly IMapper<Feature, GeolocationDto> mapper;
        private readonly SearchClientSettings configuration;

        public SearchClient(MapBoxClient client, IOptions<SearchClientSettings> settings, IMapper<Feature, GeolocationDto> mapper)
        {
            this.client = client;
            this.mapper = mapper;
            this.configuration = settings.Value;
        }

        public async Task<GeolocationDto> GetGeolocationAsync(string searchTerm)
        {
            string response = await this.client.GetStringAsync(string.Format(this.configuration.Endpoint, searchTerm));

            SearchResponse responseBody = JsonSerializer.Deserialize<SearchResponse>(response);

            return this.mapper.Map(responseBody.Features.OrderByDescending(p => p.Relevance).FirstOrDefault());
        }
    }
}
