namespace TaskerAI.Setup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.SwaggerUI;

    public static class SetupSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TSKRAI API", Version = "v1" });
                c.EnableAnnotations();
                c.ExampleFilters();
                c.OrderActionsBy(api => api.HttpMethod);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Swagger.TaskModelExample>();

            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSKRAI API");
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
