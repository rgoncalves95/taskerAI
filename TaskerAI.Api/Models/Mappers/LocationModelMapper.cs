namespace TaskerAI.Api.Models.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    public class LocationModelMapper : IMapper<Location, LocationModel>
    {
        public void Map(Location from, LocationModel to)
        {
            to.Id = from.Id ?? 0;
            to.Street = from.Street;
            to.Door = from.Door;
            to.Floor = from.Floor;
            to.Zip = from.ZipCode;
            //to.City = from.City;
            //to.Country = from.Country;
            to.Latitude = from.Latitude;
            to.Longitude = from.Longitude;
            to.Alias = from.Alias;
            to.Tags = from.Tags;
        }

        public LocationModel Map(Location from)
        {
            var to = new LocationModel();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<Location> from, IEnumerable<LocationModel> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<LocationModel> Map(IEnumerable<Location> from) => from.Select(f => Map(f)).ToArray();
    }
}
