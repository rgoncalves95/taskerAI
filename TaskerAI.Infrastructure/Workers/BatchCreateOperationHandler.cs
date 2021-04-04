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

    public abstract class BatchCreateOperationHandler<TDomain, TDto> : IWorkerOperationHandler where TDomain : Domain.Entities.BaseEntity 
    {
        private readonly IEnumerable<IContentParser<IEnumerable<TDto>>> contentParser;
        private readonly IEnumerable<IEnricher<TDto>> enrichers;
        private readonly IDomainRepository<TDomain> repository;
        private readonly ILogger<BatchCreateOperationHandler<TDomain, TDto>> logger;
        private readonly IValidator<TDto> validator;

        public BatchCreateOperationHandler(IEnumerable<IContentParser<IEnumerable<TDto>>> contentParser,
                                           IEnumerable<IEnricher<TDto>> enrichers,
                                           IDomainRepository<TDomain> repository,
                                           ILogger<BatchCreateOperationHandler<TDomain, TDto>> logger,
                                           IValidator<TDto> validator)
        {
            this.contentParser = contentParser;
            this.enrichers = enrichers;
            this.repository = repository;
            this.logger = logger;
            this.validator = validator;
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
                    failureReasons.Add($"Validation error processing row {i + 1}. {reason}");
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

                    await this.repository.CreateAsync(CreateDomainEntity(dto, operation.Body));

                }
                catch (Exception)
                {
                    //logger.LogInformation();
                    failureReasons.Add("");
                }
            }

            //TODO save failed WorkerOperation
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
