namespace TaskerAI.Setup
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using TaskerAI.ConfigurationOptions;
    using TaskerAI.Infrastructure.MapBox;

    public static class SetupConfiguration
    {
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfigureOptions<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>, ApiBehaviorOptions>();

            services.Configure<MapBoxClientSettings>(configuration.GetSection("MapBoxConfiguration"));
            services.Configure<SearchClientSettings>(configuration.GetSection("MapBoxConfiguration:SearchEndpoint"));
            services.Configure<MatrixClientSettings>(configuration.GetSection("MapBoxConfiguration:MatrixEndpoint"));

            return services;
        }
    }
}