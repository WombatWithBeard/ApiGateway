using ApiGateway.Common;
using Application.Tools;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            
            services.AddApplication(Configuration);
            
            const string authenticationProviderKey = "TestKey"; //need to take away from this place

            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.Authority = "https://localhost:4501";
                    options.Audience = "gateway";
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudiences = new [] {"ApiOne", "ApiTwo"} //need to take it from db
                    };
                });

            services.AddHttpContextAccessor();
            
            services.AddControllers();
            
            services.AddOcelot(Configuration);

            services.AddHealthChecks();
            
            services.AddOpenApiDocument(config => { config.Title = "Sir API gateway service"; });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            // {
            //     var context = scope.ServiceProvider.GetRequiredService<ApiGetwayDbContext>();
            //     await context.Database.EnsureDeletedAsync();
            //     await context.Database.EnsureCreatedAsync();
            //     // await context.Database.MigrateAsync();
            // }

            app.UseCustomExceptionHandler();
            
            app.UseHealthChecks("/health");

            app.UseOpenApi();

            app.UseSwaggerUi3(settings => { settings.Path = "/swagger"; });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
            });

            await app.UseOcelot();
        }
    }
}