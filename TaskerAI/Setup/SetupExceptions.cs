namespace TaskerAI.Setup
{
    using System;
    using Community.AspNetCore.ExceptionHandling;
    using Community.AspNetCore.ExceptionHandling.Mvc;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public static class SetupExceptions
    {
        public static IServiceCollection AddExceptionPolicies(this IServiceCollection services)
        {
            //services.AddExceptionHandlingPolicies(options =>
            //{
            //    options.For<Exception>()
            //           .Log(lo =>
            //           {
            //               lo.LogAction = (l, c, e) => l.LogError(e, "UnhandledException");
            //               lo.Category = (context, exception) => "MyCategory";
            //           })
            //          .Response(null, ResponseAlreadyStartedBehaviour.GoToNextHandler)
            //          .ClearCacheHeaders()
            //          .WithObjectResult((r, e) => new { msg = e.Message, path = r.Path })
            //          .Handled();
            //});

            return services;
        }

        public static IApplicationBuilder UseExceptionPolicies(this IApplicationBuilder app)
        {
            app.UseExceptionHandlingPolicies();

            return app;
        }
    }
}
