namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Dapper;
    using TaskerAI.Persistence;

    public static class SetupApp
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IPlanRepository, PlanRepository>();

            return services;
        }
    }
}
