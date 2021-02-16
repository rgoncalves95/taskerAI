namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Api.ActionResults;
    using TaskerAI.Api.Models.Mappers;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Workers;
    using TaskerAI.MockRepository;

    public static class SetupApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) => services.AddDomain().AddInfrastructure().AddPersistence().AddApi();

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

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(s
                => s.FromAssemblyOf<IWorker>()
                    .AddClasses(c => c.AssignableTo<IWorker>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

            services.AddSingleton<IWorkerManager, WorkerManager>();
            
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
    }
}
