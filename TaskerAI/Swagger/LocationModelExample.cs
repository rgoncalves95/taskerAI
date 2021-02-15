namespace TaskerAI.Swagger
{
    using System.Diagnostics.CodeAnalysis;
    using Swashbuckle.AspNetCore.Filters;
    using TaskerAI.Api.Models;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class LocationModelExample : IExamplesProvider<LocationModel>
    {
        private readonly IMapper<Location, LocationModel> mapper;

        public LocationModelExample(IMapper<Location, LocationModel> mapper) => this.mapper = mapper;

        public LocationModel GetExamples()
            => this.mapper.Map(Location.Create("Rua do Almada",
                                               "120",
                                               null,
                                               "4050-031",
                                               "Porto",
                                               "Portugal",
                                               "41.1472201",
                                               "-8.6142667",
                                               "HARD ROCK",
                                               new[] { "BAR", "DRINKS", "FOOD", "ROCK" }));
    }
}
