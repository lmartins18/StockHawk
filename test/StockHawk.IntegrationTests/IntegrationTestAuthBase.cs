using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using StockHawk.IntegrationTests.Helpers;

namespace StockHawk.IntegrationTests
{
    public abstract class IntegrationTestAuthBase : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly HttpClient Client;

        protected IntegrationTestAuthBase(CustomWebApplicationFactory<Program> factory)
        {
            Client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("TestScheme")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("TestScheme", options => { });
                });
            }).CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("TestScheme");
        }
    }
}
