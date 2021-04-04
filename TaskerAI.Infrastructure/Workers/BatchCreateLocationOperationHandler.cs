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

    public class BatchCreateLocationOperationHandler : BatchCreateOperationHandler<Location, LocationDto>
    {
        public BatchCreateLocationOperationHandler(IEnumerable<IContentParser<IEnumerable<LocationDto>>> contentParser,
                                                   IEnumerable<IEnricher<LocationDto>> enrichers,
                                                   IDomainRepository<Location> repository,
                                                   ILogger<BatchCreateOperationHandler<Location, LocationDto>> logger,
                                                   IValidator<LocationDto> validator)
            : base(contentParser, enrichers, repository, logger, validator)
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