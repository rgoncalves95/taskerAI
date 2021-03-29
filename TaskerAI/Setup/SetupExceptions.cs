namespace TaskerAI.Setup
{
    using System;
    using Community.AspNetCore.ExceptionHandling;
    using Community.AspNetCore.ExceptionHandling.Mvc;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using TaskerAI.Domain.Exceptions;
    using TaskerAI.Infrastructure.Workers;

    public static class SetupExceptions
    {
        public static IServiceCollection AddExceptionPolicies(this IServiceCollection services)
        {
            //TODO log internal error message and display user facing messages
            services.AddExceptionHandlingPolicies(options =>
            {
                options.For<DomainException>()
                       .Log(lo =>
                       {
                           lo.LogAction = (l, c, e) => l.LogError(e, "DomainException");
                           lo.Category = (context, exception) => "Expected";
                       })
                       .NextPolicy();

                options.For<EntityIntegrityException>()
                       .Response(e => StatusCodes.Status400BadRequest, ResponseAlreadyStartedBehaviour.GoToNextHandler)
                       .ClearCacheHeaders()
                       .WithObjectResult((r, e) => new { e.Message, e.IntegrityFaults })
                       .Handled();

                options.For<WorkerNotFoundException>()
                       .Response(e => StatusCodes.Status404NotFound, ResponseAlreadyStartedBehaviour.GoToNextHandler)
                       .ClearCacheHeaders()
                       .WithObjectResult((r, e) => new { e.Message })
                       .Handled();

                options.For<Exception>()
                       .Log(lo =>
                       {
                           lo.LogAction = (l, c, e) => l.LogError(e, "UnhandledException");
                           lo.Category = (context, exception) => "MyCategory";
                       })
                       .Response(e => 500, ResponseAlreadyStartedBehaviour.GoToNextHandler)
                       .ClearCacheHeaders()
                       .WithObjectResult((r, e) => new { msg = e.Message, endpoint = $"{r.Method} {r.Path}" })
                       .Handled();
            });

            return services;
        }

        public static IApplicationBuilder UseExceptionPolicies(this IApplicationBuilder app)
        {
            app.UseExceptionHandlingPolicies();

            return app;
        }
    }
}
