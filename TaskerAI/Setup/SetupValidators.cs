namespace TaskerAI.Setup
{
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Api.Models;
    using TaskerAI.Api.Models.Validators;

    public static class SetupValidators
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<TaskModel>, TaskModelValidator>();
            services.AddTransient<IValidator<TaskTypeModel>, TaskTypeModelValidator>();

            return services;
        }
    }
}
