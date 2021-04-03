namespace TaskerAI.Infrastructure.Dto.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Common;

    public class LocationDtoMapper : IMapper<Dictionary<string, string>, LocationDto>
    {
        public void Map(Dictionary<string, string> from, LocationDto to)
        {
            var helper = new MappingHelper(to);

            foreach (KeyValuePair<string, string> property in from)
            {
                helper[property.Key] = property.Value;
            }
        }

        public LocationDto Map(Dictionary<string, string> from)
        {
            var to = new LocationDto();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<Dictionary<string, string>> from, IEnumerable<LocationDto> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<LocationDto> Map(IEnumerable<Dictionary<string, string>> from) => from.Select(f => Map(f)).ToArray();

        private class MappingHelper
        {
            private readonly Dictionary<string, Action<string>> actions;

            public MappingHelper(LocationDto dto)
            {
                this.actions = new Dictionary<string, Action<string>>()
                {
                    { "A", s => dto.Street = s },
                    { "B", s => dto.Door = s },
                    { "C", s => dto.Floor = s },
                    { "D", s => dto.ZipCode = s },
                    { "E", s => dto.City = s },
                    { "F", s => dto.Country = s },
                    { "G", s => dto.Alias = s },
                    { "H", s => dto.Tags = s != null ? s.Split("|") : Array.Empty<string>() }
                };
            }

            public string this[string index]
            {
                set => this.actions[index](value);
            }
        }
    }
}
