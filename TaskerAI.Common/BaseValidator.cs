namespace TaskerAI.Common
{
    using System;
    using System.Linq.Expressions;
    using FluentValidation;

    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected void Required<TProperty>(Expression<Func<T, TProperty>> expression)
            => RuleFor(expression).NotEmpty().WithMessage(p => Format(expression));

        private static string Format<TProperty>(Expression<Func<T, TProperty>> expression)
            => string.Format(ValidationMessages.Required, ((MemberExpression)expression.Body).Member.Name);
    }
    public struct ValidationMessages
    {
        public const string Required = "{0} is required.";
    }
}
