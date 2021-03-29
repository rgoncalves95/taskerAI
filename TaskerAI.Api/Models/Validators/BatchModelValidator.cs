namespace TaskerAI.Api.Models.Validators
{
    using System;
    using System.Linq;
    using FluentValidation;

    public class BatchModelValidator : BaseFileValidator<BatchModel>
    {
        protected override string[] SupportedMediaTypeUploads => new[] { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };
        private string[] SupportedEntities => new[] { nameof(Domain.Entities.Location) };

        public BatchModelValidator()
        {
            Required(p => p.File);
            Required(p => p.Entity);

            When(p => p.File != null, () => SupportedMediaType(p => p.File));
            When(p => p.Entity != null, () => RuleFor(p => p.Entity).Must(p => this.SupportedEntities.Contains(p, StringComparer.OrdinalIgnoreCase))
                                                                    .WithMessage("Unsupported Entity Type"));
        }
    }
}
