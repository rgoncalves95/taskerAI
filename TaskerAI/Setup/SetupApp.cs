namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Api.Mapper;
    using TaskerAI.Api.Models;
    using TaskerAI.MockRepository;
    using TaskerAI.Domain;
    using TaskerAI.Infrastructure;
    using TaskerAI.Persistence;

    public static class SetupApp
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            return services;
        }

        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<Plan, PlanModel>, PlanMapper>();
            services.AddSingleton<IMapper<Task, TaskModel>, TaskMapper>();
            services.AddSingleton<IMapper<User, UserModel>, UserMapper>();

            return services;
        }
    }
}
