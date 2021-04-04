namespace TaskerAI.Common
{
    using System;
    using System.Linq.Expressions;
    using FluentValidation;

    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected IRuleBuilderOptions<T, TProperty> Required<TProperty>(Expression<Func<T, TProperty>> expression)
            => RuleFor(expression).NotEmpty().WithMessage(p => Format(expression, ValidationMessages.Required));

        protected void ValidDateFormat(Expression<Func<T, string>> expression)
            => Required(expression).DependentRules(() => RuleFor(expression).Must(v => DateTime.TryParse(v, out _)).WithMessage(p => Format(expression, ValidationMessages.InvalidDateFormat)));

        private static string Format<TProperty>(Expression<Func<T, TProperty>> expression, string message)
            => string.Format(message, ((MemberExpression)expression.Body).Member.Name);
    }

    public struct ValidationMessages
    {
        public const string Required = "{0} is required.";
        public const string InvalidDateFormat = "{0} has and invalid date format.";
    }
}
