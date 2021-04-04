namespace TaskerAI.Infrastructure.Workers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.Extensions.Logging;
    using TaskerAI.Common;
    using TaskerAI.Domain.Repositories;
    using TaskerAI.Infrastructure.Repositories;

    public abstract class BatchCreateOperationHandler<TDomain, TDto> : IWorkerOperationHandler where TDomain : Domain.Entities.BaseEntity
    {
        private readonly IEnumerable<IContentParser<IEnumerable<TDto>>> contentParser;
        private readonly IEnumerable<IEnricher<TDto>> enrichers;
        private readonly IValidator<TDto> validator;
        private readonly IDomainRepository<TDomain> repository;
        private readonly IWorkerOperationStatusRepository workerOperationStatusRepository;
        private readonly ILogger<BatchCreateOperationHandler<TDomain, TDto>> logger;

        public BatchCreateOperationHandler(IEnumerable<IContentParser<IEnumerable<TDto>>> contentParser,
                                           IEnumerable<IEnricher<TDto>> enrichers,
                                           IValidator<TDto> validator,
                                           IDomainRepository<TDomain> repository,
                                           IWorkerOperationStatusRepository workerOperationStatusRepository,
                                           ILogger<BatchCreateOperationHandler<TDomain, TDto>> logger)
        {
            this.contentParser = contentParser;
            this.enrichers = enrichers;
            this.validator = validator;
            this.repository = repository;
            this.workerOperationStatusRepository = workerOperationStatusRepository;
            this.logger = logger;
        }

        public string OperationEntity => typeof(TDomain).Name;

        public async Task HandleAsync(WorkerOperation operation)
        {
            IContentParser<IEnumerable<TDto>> parser = this.contentParser.FirstOrDefault(p => p.ContentType == operation.ContentType);

            if (parser == null)
            {
                //TODO handler null parser
            }

            TDto[] dtos = parser.Parse(operation.Content).ToArray();

            var failureReasons = new List<string>();

            for (int i = 0; i < dtos.Length; i++)
            {
                TDto dto = dtos[i];

                if (!IsValid(dto, out string reason))
                {
                    failureReasons.Add($"Validation error processing row {i + 1}. {reason}.");
                    continue;
                }

                try
                {
                    var enrichers = new List<Task>();

                    foreach (IEnricher<TDto> enricher in this.enrichers)
                    {
                        enrichers.Add(enricher.EnrichAsync(dto));
                    }

                    await Task.WhenAll(enrichers);

                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Failed to process row {i + 1} while running enricher.",
                        new { operation.Id, operation.JobId, operation.ContentType, operation.Entity }, dto);

                    failureReasons.Add($"Failed to process row {i + 1}.");
                }

                await this.repository.CreateAsync(CreateDomainEntity(dto, operation.Body));
            }

            if (failureReasons.Count > 0)
            {
                await this.workerOperationStatusRepository.CreateAsync(operation, failureReasons);
            }
        }

        protected abstract TDomain CreateDomainEntity(TDto dto, string additionalData);

        private bool IsValid(TDto dto, out string reason)
        {
            ValidationResult result = this.validator.Validate(dto);

            reason = result.ToString(" ");

            return result.IsValid;
        }
    }
}
