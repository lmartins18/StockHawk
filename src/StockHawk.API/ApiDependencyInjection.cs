using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StockHawk.API;

public static class ApiDependencyInjection
{
    public static void AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog((srv, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(srv)
            .Enrich.FromLogContext()
            .WriteTo.Console());
    }

    public static void AddSwaggerGenWithOAuth(this IServiceCollection services, OpenApiOAuthFlow oAuthFlow,
        Action<SwaggerGenOptions>? setupAction = null)
    {
        services.AddSwaggerGen(c =>
        {
            var OATH2 = "oauth2";

            // Ref Enabled OAuth security in Swagger. From here: https://stackoverflow.com/questions/66894523/swagger-not-able-to-authenticate-to-azure-ad-b2c
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = OATH2
                        }
                    },
                    new List<string>()
                }
            });

            c.AddSecurityDefinition(OATH2, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = oAuthFlow
                }
            });
            setupAction?.Invoke(c);
        });
    }
}