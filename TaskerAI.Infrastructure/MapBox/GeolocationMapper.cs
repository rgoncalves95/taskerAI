namespace TaskerAI.Infrastructure.MapBox
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Dto;

    internal class GeolocationMapper : IMapper<Feature, GeolocationDto>
    {
        public void Map(Feature from, GeolocationDto to)
        {
            to.Longitude = from.Geometry?.Coordinates?.First().ToString();
            to.Latitude = from.Geometry?.Coordinates?.Last().ToString();
        }

        public GeolocationDto Map(Feature from)
        {
            var to = new GeolocationDto();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<Feature> from, IEnumerable<GeolocationDto> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<GeolocationDto> Map(IEnumerable<Feature> from) => from.Select(f => Map(f)).ToArray();
    }
}
