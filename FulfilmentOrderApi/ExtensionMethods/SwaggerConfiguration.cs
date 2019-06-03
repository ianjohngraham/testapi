using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FulfilmentOrderApi.ExtensionMethods
{
    public static class SwaggerConfiguration
    {
        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fulfilment API V1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
