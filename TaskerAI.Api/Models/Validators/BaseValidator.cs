namespace TaskerAI.Api.Models.Validators
{
    using FluentValidation;
    using System;
    using System.Linq.Expressions;

    public class BaseValidator<T> : AbstractValidator<T>
    {
        protected void Required<TProperty>(Expression<Func<T, TProperty>> expression) => RuleFor(expression).NotEmpty().WithMessage(p => Format(expression));

        private static string Format<TProperty>(Expression<Func<T, TProperty>> expression) => string.Format(ValidationMessages.Required, ((MemberExpression)expression.Body).Member.Name);
    }
}
