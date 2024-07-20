using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Serilog;
using StockHawk.API;
using StockHawk.DataAccess;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSerilogLogging(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddDataAccess(builder.Configuration);
// CORS
var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
// Need exception here.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => { policy.WithOrigins(corsOrigins).AllowAnyHeader(); });
});
builder.Services.AddScoped<StockHawkDbContext>();
builder.Services.AddProblemDetails();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add swagger with OAuth
var scopesList = builder.Configuration.GetSection("AzureAdB2C:Scopes").Get<List<string>>();
// Need exception here if no scopes.
var scopesDic = scopesList.ToDictionary(scope => scope, scope => scope);
var oAuthFlow = new OpenApiOAuthFlow()
{
    AuthorizationUrl = new Uri($"{builder.Configuration["AzureAdB2C:Instance"]}/{builder.Configuration["AzureAdB2C:Domain"]}/{builder.Configuration["AzureAdB2C:SignUpSignInPolicyId"]}/oauth2/v2.0/authorize"),
    TokenUrl = new Uri($"{builder.Configuration["AzureAdB2C:Instance"]}/{builder.Configuration["AzureAdB2C:Domain"]}/{builder.Configuration["AzureAdB2C:SignUpSignInPolicyId"]}/oauth2/v2.0/token"),
    Scopes = scopesDic
};

builder.Services.AddSwaggerGenWithOAuth(oAuthFlow);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var swaggerConfig = builder.Configuration.GetSection("Swagger");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId(swaggerConfig.GetSection("ClientId").Value);
        options.OAuthClientSecret(swaggerConfig.GetSection("ClientSecret").Value);
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