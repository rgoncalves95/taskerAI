namespace TaskerAI.Setup
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Application;

    public static class SetupMediatr
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePlanCommand));

            return services;
        }
    }
}
