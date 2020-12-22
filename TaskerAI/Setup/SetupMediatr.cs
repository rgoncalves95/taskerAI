namespace TaskerAI.Setup
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Application;

    public static class SetupMediatr
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            //services.AddTransient<IMediator, Mediator>();
            //services.AddTransient<ServiceFactory>(p => p.GetService);

            //services.AddTransient<IRequestHandler<CreatePlanCommand>, CreatePlanCommandHandler>();
            //services.AddTransient<IRequestHandler<GetPlanQuery, object>, GetPlanQueryHandler>();

            services.AddMediatR(typeof(CreatePlanCommand));

            return services;
        }
    }
}
