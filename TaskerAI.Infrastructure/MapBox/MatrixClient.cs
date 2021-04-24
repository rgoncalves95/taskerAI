namespace TaskerAI.Infrastructure.MapBox
{
    using System.Globalization;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Dto;

    public class MatrixClient: IMatrixRouteProvider
    {
        private readonly MapBoxClient client;
        private readonly MatrixClientSettings configuration;
        private readonly IMapper<MatrixResponse, MatrixRouteDto> _mapper;

        public MatrixClient(MapBoxClient client, IOptions<MatrixClientSettings> settings, IMapper<MatrixResponse, MatrixRouteDto> mapper)
        {
            this.client = client;
            this.configuration = settings.Value;
            _mapper = mapper;
        }

        public async Task<MatrixRouteDto> GetMatrixRoutes(float[][] coordinates)
        {
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            var coordinatesBuilder = new StringBuilder();
            foreach(var coordinate in coordinates)
            {
                coordinatesBuilder.Append($"{coordinate[0].ToString(nfi)},{coordinate[1].ToString(nfi)};");
            }

            var locations = coordinatesBuilder.ToString(0,coordinatesBuilder.Length - 1);

            string response = await this.client.GetStringAsync(string.Format(this.configuration.Endpoint,"driving", locations, "distance,duration"));

            MatrixResponse responseBody = JsonSerializer.Deserialize<MatrixResponse>(response);

            return _mapper.Map(responseBody);
        }
    }
}
