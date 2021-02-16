namespace TaskerAI.Setup
{
    using Hangfire;
    using Hangfire.MemoryStorage;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class SetupHangfire
    {
        public static IServiceCollection AddHangfire(this IServiceCollection services) => services.AddHangfire(c => c.UseMemoryStorage());

        public static IApplicationBuilder UseHangfire(this IApplicationBuilder app)
        {
            return app.UseHangfireServer()
                      .UseHangfireDashboard();
        }
    }
}
