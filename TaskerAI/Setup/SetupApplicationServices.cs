namespace TaskerAI.Setup
{
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Api.ActionResults;
    using TaskerAI.Api.Models.Mappers;
    using TaskerAI.Common;
    using TaskerAI.Common.TaskerAI.Common;
    using TaskerAI.Infrastructure;
    using TaskerAI.Infrastructure.Dto;
    using TaskerAI.Infrastructure.MapBox;
    using TaskerAI.Infrastructure.Workers;
    using TaskerAI.MockRepository;

    public static class SetupApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) => services.AddDomain().AddInfrastructure().AddPersistence().AddApi().AddCommon();

        private static IServiceCollection AddDomain(this IServiceCollection services) => services;

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblyOf<TaskRepository>()
                                .AddClasses(c => c.Where(type => type.Name.EndsWith("Repository")))
                                .AsImplementedInterfaces()
                                .WithSingletonLifetime());

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblyOf<IWorker>()
                                .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
                                .AsImplementedInterfaces()
                                .AddClasses(c => c.AssignableTo(typeof(IWorker)))
                                .AsImplementedInterfaces()
                                .AddClasses(c => c.AssignableTo(typeof(IEnricher<>)))
                                .AsImplementedInterfaces()
                                .WithSingletonLifetime());

            services.AddSingleton<IWorkerManager, WorkerManager>();
            services.AddSingleton<IWorkerOperationHandler, BatchCreateLocationOperationHandler>();

            services.AddSingleton<IGeolocationProvider, SearchClient>();

            return services;
        }

        private static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddSingleton<IContentParser<IEnumerable<LocationDto>>, SpreadsheetParser<LocationDto>>();

            return services;
        }

        private static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblyOf<TaskModelMapper>()
                                .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
                                .AsImplementedInterfaces()
                                .WithSingletonLifetime());

            services.AddSingleton<IRequestResultFactory, RequestResultFactory>();

            return services;
        }
    }
}
