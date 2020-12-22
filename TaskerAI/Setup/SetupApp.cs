using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskerAI.Application;
using TaskerAI.Dapper;
using TaskerAI.Persistence;

namespace TaskerAI.Setup
{
    public static class SetupApp
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddTransient<IPlanRepository, PlanRepository>();

            return services;
        }
    }
}
