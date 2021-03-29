namespace TaskerAI
{
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TaskerAI.Setup;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson()
                    .AddFluentValidation(c => c.ImplicitlyValidateChildProperties = true);
            services.AddConfigurationOptions(this.Configuration);
            services.AddExceptionPolicies();
            services.AddApplicationServices();
            services.AddValidators();
            services.AddMediatr();
            services.AddSwagger();
            services.AddHangfire();
            services.AddHttpClient(this.Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionPolicies();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseHangfire();
        }
    }
}
