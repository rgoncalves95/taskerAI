namespace TaskerAI.Infrastructure.Dto.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Common;

    public class TaskDtoMapper : IMapper<Dictionary<string, string>, TaskDto>
    {
        public void Map(Dictionary<string, string> from, TaskDto to)
        {
            var helper = new MappingHelper(to);

            foreach (KeyValuePair<string, string> property in from)
            {
                helper[property.Key] = property.Value;
            }
        }

        public TaskDto Map(Dictionary<string, string> from)
        {
            var to = new TaskDto();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<Dictionary<string, string>> from, IEnumerable<TaskDto> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<TaskDto> Map(IEnumerable<Dictionary<string, string>> from) => from.Select(f => Map(f)).ToArray();

        private class MappingHelper
        {
            private readonly Dictionary<string, Action<string>> actions;

            public MappingHelper(TaskDto dto)
            {
                this.actions = new Dictionary<string, Action<string>>()
                {
                    { "A", s => dto.Name = s },
                    { "B", s => dto.Date = s },
                    { "C", s => dto.DueDate = s },
                    { "D", s => dto.DurationInSeconds = s },
                    { "E", s => dto.Location.Street = s },
                    { "F", s => dto.Location.Door = s },
                    { "G", s => dto.Location.Floor = s },
                    { "H", s => dto.Location.ZipCode = s },
                    { "I", s => dto.Location.City = s },
                    { "J", s => dto.Location.Country = s },
                    { "K", s => dto.Location.Alias = s },
                    { "L", s => dto.Location.Tags = s != null ? s.Split("|") : Array.Empty<string>() },
                    { "M", s => dto.Notes = s }
                };
            }

            public string this[string index]
            {
                set => this.actions[index](value);
            }
        }
    }
}
