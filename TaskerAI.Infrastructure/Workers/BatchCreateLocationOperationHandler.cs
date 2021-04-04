namespace TaskerAI.Infrastructure.Workers
{
    using System.Collections.Generic;
    using FluentValidation;
    using Microsoft.Extensions.Logging;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;
    using TaskerAI.Domain.Repositories;
    using TaskerAI.Infrastructure;
    using TaskerAI.Infrastructure.Dto;
    using TaskerAI.Infrastructure.Repositories;

    public class BatchCreateLocationOperationHandler : BatchCreateOperationHandler<Location, LocationDto>
    {
        public BatchCreateLocationOperationHandler(IEnumerable<IContentParser<IEnumerable<LocationDto>>> contentParser,
                                                   IEnumerable<IEnricher<LocationDto>> enrichers,
                                                   IValidator<LocationDto> validator,
                                                   IDomainRepository<Location> repository,
                                                   IWorkerOperationStatusRepository workerOperationStatusRepository,
                                                   ILogger<BatchCreateLocationOperationHandler> logger)
        : base(contentParser, enrichers, validator, repository, workerOperationStatusRepository, logger)
        {
        }

        protected override Location CreateDomainEntity(LocationDto dto, string additionalData)
        {
            return Location.Create(dto.Street,
                                   dto.Door,
                                   dto.Floor,
                                   dto.ZipCode,
                                   dto.City,
                                   dto.Country,
                                   dto.Latitude,
                                   dto.Longitude,
                                   dto.Alias,
                                   dto.Tags);
        }
    }
}