using System;
using System.Linq;
using FluentValidation;

namespace TaskerAI.Api.Models.Validators
{
    public class BatchModelValidator : BaseFileValidator<BatchModel>
    {
        protected override string[] SupportedMediaTypeUploads => new[] { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };
        private string[] SupportedEntities => new[] { nameof(Domain.Entities.Location) };

        public BatchModelValidator()
        {
            Required(p => p.File);
            Required(p => p.Entity);

            When(p => p.File != null, () => SupportedMediaType(p => p.File));
            When(p => p.Entity != null, () => RuleFor(p => p.Entity).Must(p => SupportedEntities.Contains(p, StringComparer.OrdinalIgnoreCase))
                                                                    .WithMessage("Unsupported Entity Type"));
        }
    }
}
