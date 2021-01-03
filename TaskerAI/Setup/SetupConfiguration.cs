namespace TaskerAI.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using TaskerAI.ConfigurationOptions;

    public static class SetupConfiguration
    {
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services)
        {
            services.AddSingleton<IConfigureOptions<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>, ApiBehaviorOptions>();

            return services;
        }
    }
}