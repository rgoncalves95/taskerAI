namespace TaskerAI.Api.Models.Validators
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;

    public abstract class BaseFileValidator<T> : BaseValidator<T>
    {
        protected abstract string[] SupportedMediaTypeUploads { get; }

        protected void SupportedMediaType(Expression<Func<T, IFormFile>> expression)
            => RuleFor(expression).Must(m => m.ContentType != null && SupportedMediaTypeUploads.Contains(m.ContentType))
                                  .WithMessage("Unsupported Media Type");
    }

}
