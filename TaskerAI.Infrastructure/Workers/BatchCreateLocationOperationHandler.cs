namespace TaskerAI.Infrastructure.Workers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation.Results;
    using Microsoft.Extensions.Logging;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;
    using TaskerAI.Infrastructure.Dto;

    public class BatchCreateLocationOperationHandler : IWorkerOperationHandler
    {
        private readonly IEnumerable<IContentParser<IEnumerable<LocationDto>>> contentParser;
        private readonly IEnumerable<IEnricher<LocationDto>> enrichers;
        private readonly ILocationRepository repository;
        private readonly ILogger<BatchCreateLocationOperationHandler> logger;

        public BatchCreateLocationOperationHandler(IEnumerable<IContentParser<IEnumerable<LocationDto>>> contentParser,
                                                   IEnumerable<IEnricher<LocationDto>> enrichers,
                                                   ILocationRepository repository,
                                                   ILogger<BatchCreateLocationOperationHandler> logger)
        {
            this.contentParser = contentParser;
            this.enrichers = enrichers;
            this.repository = repository;
            this.logger = logger;
        }

        public string OperationEntity => nameof(Domain.Entities.Location);

        public async Task HandleAsync(WorkerOperation operation)
        {
            IContentParser<IEnumerable<LocationDto>> parser = this.contentParser.FirstOrDefault(p => p.ContentType == operation.ContentType);

            if (parser == null)
            {
                //TODO handler null parser
            }

            LocationDto[] dtos = parser.Parse(operation.Content).ToArray();

            var failureReasons = new List<string>();

            for (int i = 0; i < dtos.Length; i++)
            {
                LocationDto dto = dtos[i];

                if (!IsValid(dto, out string reason))
                {
                    failureReasons.Add($"Validation error processing row {i + 1}. {reason}");
                    continue;
                }

                try
                {
                    var enrichers = new List<Task>();

                    foreach (IEnricher<LocationDto> enricher in this.enrichers)
                    {
                        enrichers.Add(enricher.EnrichAsync(dto));
                    }

                    await Task.WhenAll(enrichers);

                    await this.repository.CreateAsync(
                        Domain.Entities.Location.Create(dto.Street,
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
                catch (Exception)
                {
                    //logger.LogInformation();
                    failureReasons.Add("");
                }
            }

            //TODO save failed WorkerOperation
        }

        private bool IsValid(LocationDto dto, out string reason)
        {
            ValidationResult result = new CreateLocationDtoValidator().Validate(dto);

            reason = result.ToString(" ");

            return result.IsValid;
        }
    }
}
