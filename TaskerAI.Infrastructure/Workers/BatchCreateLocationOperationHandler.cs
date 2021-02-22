namespace TaskerAI.Infrastructure.Workers
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;
    using TaskerAI.Infrastructure;
    using TaskerAI.Infrastructure.Dto;

    public class BatchCreateLocationOperationHandler : IWorkerOperationHandler
    {
        private readonly IEnumerable<IContentParser<IEnumerable<LocationDto>>> contentParser;
        private readonly IEnumerable<IEnricher<LocationDto>> enrichers;
        private readonly ILocationRepository repository;

        public BatchCreateLocationOperationHandler(IEnumerable<IContentParser<IEnumerable<LocationDto>>> contentParser,
                                    IEnumerable<IEnricher<LocationDto>> enrichers,
                                    ILocationRepository repository)
        {
            this.contentParser = contentParser;
            this.enrichers = enrichers;
            this.repository = repository;
        }

        public string OperationEntity => nameof(Location);

        public void Handle(WorkerOperation operation)
        {
            IContentParser<IEnumerable<LocationDto>> parser = this.contentParser.FirstOrDefault(p => p.ContentType == operation.ContentType);

            if (parser == null)
            {
                //TODO handler null parser
            }

            IEnumerable<LocationDto> dtos = parser.Parse(operation.Content);

            foreach (LocationDto dto in dtos)
            {
                foreach (IEnricher<LocationDto> enricher in this.enrichers)
                {
                    enricher.Enrich(dto);
                }

                this.repository.CreateAsync(Location.Create(dto.Street,
                                                            dto.Door,
                                                            dto.Floor,
                                                            dto.ZipCode,
                                                            dto.City,
                                                            dto.Country,
                                                            dto.Latitude,
                                                            dto.Longitude,
                                                            dto.Alias,
                                                            dto.Tags));
            }
        }
    }
}
