namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Infrastructure.MapBox;

    public static class SetupServiceClients
    {
        public static IServiceCollection AddServiceClients(this IServiceCollection services)
        {
            //TODO add circuit breaker https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-circuit-breaker-pattern
            services.AddHttpClient<MapBoxClient>();

            return services;
        }
    }
}
