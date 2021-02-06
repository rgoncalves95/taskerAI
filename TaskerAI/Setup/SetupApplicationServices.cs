namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Api.ActionResults;
    using TaskerAI.Api.Mapper;
    using TaskerAI.Api.Models;
    using TaskerAI.Api.Models.Mappers;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.MockRepository;

    public static class SetupApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) => services.AddDomain().AddPersistence().AddApi();

        private static IServiceCollection AddDomain(this IServiceCollection services) => services;

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IPlanRepository>(p => null);
            services.AddTransient<IUserRepository>(p => null);
            services.AddTransient<ITaskRepository, TaskRepository>();

            return services;
        }

        private static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<Plan, PlanModel>, PlanMapper>();
            services.AddSingleton<IMapper<Task, TaskModel>, TaskModelMapper>();
            services.AddSingleton<IMapper<User, UserModel>, UserMapper>();
            services.AddSingleton<IRequestResultFactory, RequestResultFactory>();

            return services;
        }
    }
}
