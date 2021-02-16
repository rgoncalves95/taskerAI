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
            //services.Scan(s
            //    => s.FromAssemblyOf<TaskModelValidator>()
            //        .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
            //        .AsImplementedInterfaces()
            //        .WithSingletonLifetime());

            services.AddTransient<IValidator<TaskModel>, TaskModelValidator>();
            services.AddTransient<IValidator<TaskTypeModel>, TaskTypeModelValidator>();
            services.AddTransient<IValidator<LocationModel>, LocationModelValidator>();
            services.AddTransient<IValidator<BatchModel>, BatchModelValidator>();

            return services;
        }
    }
}
