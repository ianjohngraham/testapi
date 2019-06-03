using FulfilmentOrderApi.Domain.Models;
using FulfilmentOrderApi.Infrastructure;
using FulfilmentOrderApi.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FulfilmentOrderApi.ExtensionMethods
{
    public static class ServiceRegistration
    {
        public static void AddFulfilmentApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IColourMatch, ConfigurationBasedColourMatch>();

            var settings = new ColourMatchMappings();
            configuration.Bind("ColourMatchMappings", settings);
            services.AddSingleton(settings);
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            var generator = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Fulfilment Order API",
                    Version = "v1",
                    Description = "Sends Orders to Fulfilment Partners and Matches Colour from Url"
                });
            }
            );
        }
    }
}
