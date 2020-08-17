using Microsoft.Extensions.DependencyInjection;

namespace ProAgil.Application.Api.Config
{
    public static class CorsSettings
    {
        public static void RegisterCors(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("*");
            }));
        }
    }
}