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
    using TaskerAI.Infrastructure.Repositories;

    public class BatchCreateTaskOperationHandler : BatchCreateOperationHandler<Task, TaskDto>
    {
        private readonly IJsonParser parser;

        public BatchCreateTaskOperationHandler(IEnumerable<IContentParser<IEnumerable<TaskDto>>> contentParser,
                                               IEnumerable<IEnricher<TaskDto>> enrichers,
                                               IValidator<TaskDto> validator,
                                               IDomainRepository<Task> repository,
                                               IWorkerOperationStatusRepository workerOperationStatusRepository,
                                               ILogger<BatchCreateTaskOperationHandler> logger,
                                               IJsonParser parser)
        : base(contentParser, enrichers, validator, repository, workerOperationStatusRepository, logger) => this.parser = parser;

        protected override Task CreateDomainEntity(TaskDto dto, string additionalData)
        {
            var taskType = TaskType.Create(this.parser.Deserialize<AdditionalData>(additionalData).TaskTypeId);
            var location = Location.Create(dto.Location.Street,
                                           dto.Location.Door,
                                           dto.Location.Floor,
                                           dto.Location.ZipCode,
                                           dto.Location.City,
                                           dto.Location.Country,
                                           dto.Location.Latitude,
                                           dto.Location.Longitude,
                                           dto.Location.Alias,
                                           dto.Location.Tags);
            var date = DateTimeOffset.Parse(dto.Date);
            var dueDate = DateTimeOffset.Parse(dto.DueDate);
            int duration = int.Parse(dto.DurationInSeconds);

            return Task.Create(dto.Name, taskType, location, date, dueDate, duration, dto.Notes);
        }

        private class AdditionalData
        {
            public int TaskTypeId { get; set; }
        }
    }
}