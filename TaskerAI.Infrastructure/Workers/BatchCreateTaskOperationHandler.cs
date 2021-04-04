namespace TaskerAI.Infrastructure.Workers
{
    using System;
    using System.Collections.Generic;
    using FluentValidation;
    using Microsoft.Extensions.Logging;
    using TaskerAI.Common;
    using TaskerAI.Domain.Entities;
    using TaskerAI.Domain.Repositories;
    using TaskerAI.Infrastructure;
    using TaskerAI.Infrastructure.Dto;

    public class BatchCreateTaskOperationHandler : BatchCreateOperationHandler<Task, TaskDto>
    {
        private readonly IJsonParser parser;

        public BatchCreateTaskOperationHandler(IEnumerable<IContentParser<IEnumerable<TaskDto>>> contentParser,
                                               IEnumerable<IEnricher<TaskDto>> enrichers,
                                               IDomainRepository<Task> repository,
                                               ILogger<BatchCreateOperationHandler<Task, TaskDto>> logger,
                                               IValidator<TaskDto> validator, 
                                               IJsonParser parser)
            : base(contentParser, enrichers, repository, logger, validator)
        {
            this.parser = parser;
        }

        protected override Task CreateDomainEntity(TaskDto dto, string additionalData)
        {
            const string DateFormat = "dd/MM/yyyy";

            return Task.Create(dto.Name,
                               TaskType.Create(this.parser.Deserialize<AdditionalData>(additionalData).Id),
                               Location.Create(dto.Location.Street,
                                               dto.Location.Door,
                                               dto.Location.Floor,
                                               dto.Location.ZipCode,
                                               dto.Location.City,
                                               dto.Location.Country,
                                               dto.Location.Latitude,
                                               dto.Location.Longitude,
                                               dto.Location.Alias,
                                               dto.Location.Tags),
                               DateTimeOffset.ParseExact(dto.Date, DateFormat, null),
                               DateTimeOffset.ParseExact(dto.DueDate, DateFormat, null),
                               int.Parse(dto.DurationInSeconds),
                               dto.Notes);
        }

        private class AdditionalData
        {
            public int Id { get; set; }
        }
    }
}