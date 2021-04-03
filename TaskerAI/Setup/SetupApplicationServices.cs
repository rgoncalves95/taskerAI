namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Api.ActionResults;
    using TaskerAI.Api.Models.Mappers;
    using TaskerAI.Common;
    using TaskerAI.MockRepository;
    using TaskerAI.Database;
    using Microsoft.Extensions.Configuration;

    public static class SetupApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) => services.AddDomain().AddPersistence().AddApi().AddDatabase(configuration);

        private static IServiceCollection AddDomain(this IServiceCollection services) => services;

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.Scan(s
                => s.FromAssemblyOf<TaskRepository>()
                    .AddClasses(c => c.Where(type => type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

            return services;
        }

        private static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.Scan(s
                => s.FromAssemblyOf<TaskModelMapper>()
                    .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

            services.AddSingleton<IRequestResultFactory, RequestResultFactory>();

            return services;
        }


        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {

            services.AddScoped<IDatabase>(x => new Database(config.GetConnectionString("PostgreSQL")));

            return services;
        }
    }
}
