namespace TaskerAI.Setup
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Infrastructure.MapBox;

    public static class SetupHttpClient
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO add circuit breaker https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-circuit-breaker-pattern
            services.AddHttpClient<MapBoxClient>();

            return services;
        }
    }
}
