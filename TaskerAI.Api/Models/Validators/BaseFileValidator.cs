namespace TaskerAI.Api.Models.Validators
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;
    using TaskerAI.Common;

    public abstract class BaseFileValidator<T> : BaseValidator<T>
    {
        protected abstract string[] SupportedMediaTypeUploads { get; }

        protected void SupportedMediaType(Expression<Func<T, IFormFile>> expression)
            => RuleFor(expression).Must(m => m.ContentType != null && this.SupportedMediaTypeUploads.Contains(m.ContentType))
                                  .WithMessage("Unsupported Media Type");
    }

}
