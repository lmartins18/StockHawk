using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Serilog;
using StockHawk.API;
using StockHawk.DataAccess;
using StockHawk.Service;

// Initialize Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add Serilog logging
    builder.Services.AddSerilogLogging(builder.Configuration);

    // Add Global Exception Handler
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    // Add Data Access Layer
    builder.Services.AddDataAccess(builder.Configuration);

    // Add Service Layer
    builder.Services.AddServiceLayer(builder.Configuration);

    // CORS configuration
    var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
    if (corsOrigins == null || !corsOrigins.Any())
    {
        throw new InvalidOperationException("AllowedOrigins is not configured or empty in the appsettings.");
    }

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins(corsOrigins)
                  .AllowAnyHeader()
                  .WithMethods("PUT", "DELETE", "GET", "POST");
        });
    });

    // Add ProblemDetails for better error responses
    builder.Services.AddProblemDetails();

    // Add Authentication & Authorization       Ref: https://learn.microsoft.com/en-us/azure/active-directory-b2c/enable-authentication-web-api?tabs=csharpclient
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));
    builder.Services.AddAuthorization();

    // Add Controllers
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    // Add Swagger with OAuth
    var scopesList = builder.Configuration.GetSection("AzureAdB2C:Scopes").Get<List<string>>();
    if (scopesList == null || !scopesList.Any())
    {
        throw new InvalidOperationException("AzureAdB2C:Scopes is not configured or empty in the appsettings.");
    }

    var scopesDic = scopesList.ToDictionary(scope => scope, scope => scope);

    var oAuthFlow = new OpenApiOAuthFlow
    {
        AuthorizationUrl = new Uri($"{builder.Configuration["AzureAdB2C:Instance"]}/{builder.Configuration["AzureAdB2C:Domain"]}/{builder.Configuration["AzureAdB2C:SignUpSignInPolicyId"]}/oauth2/v2.0/authorize"),
        TokenUrl = new Uri($"{builder.Configuration["AzureAdB2C:Instance"]}/{builder.Configuration["AzureAdB2C:Domain"]}/{builder.Configuration["AzureAdB2C:SignUpSignInPolicyId"]}/oauth2/v2.0/token"),
        Scopes = scopesDic
    };

    builder.Services.AddSwaggerGenWithOAuth(oAuthFlow);

    var app = builder.Build();

    // Configure Swagger if in development mode.
    if (app.Environment.IsDevelopment())
    {
        var swaggerConfig = builder.Configuration.GetSection("Swagger");
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.OAuthClientId(swaggerConfig.GetValue<string>("ClientId"));
            options.OAuthClientSecret(swaggerConfig.GetValue<string>("ClientSecret"));
        });
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseExceptionHandler();
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed.");
    throw;
}
finally
{
    Log.CloseAndFlush();
}

// Partial class for integration tests
public partial class Program { }
// Ref: https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0