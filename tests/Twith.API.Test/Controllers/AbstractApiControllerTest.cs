using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Twith.Identity.Entities;
using Twith.Identity.Services;
using Xunit;

namespace Twith.API.Test.Controllers
{
    public abstract class AbstractApiControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        protected IServiceProvider ServiceProvider;
        
        public AbstractApiControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            ServiceProvider = _factory.Services;
        }

        private HttpClient CreateClient()
        {
            return _factory.CreateClient();
        }

        protected string GetToken(ApplicationUser user)
        {
            var tokenClaimsService = ServiceProvider.GetService<ITokenClaimsService>();
            
            return tokenClaimsService.GetToken(
                tokenClaimsService.GenerateClaimsIdentityForUser(user)
            );
        }

        protected TResponse Deserialize<TResponse>(string json)
        {
            return JsonConvert.DeserializeObject<TResponse>(json);
        }

        public Task<HttpResponseMessage> SendPostAsync<TRequest>(string uri, TRequest request, string? token = null)
        {
            return SendAsync(HttpMethod.Post, uri, request, token);
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri, object? request,
            string? token)
        {
            var client = CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                method, new Uri(uri, UriKind.RelativeOrAbsolute)
            )
            {
                Content = request != null ? JsonContent.Create(request) : null,
                Headers =
                {
                    Authorization = token != null ? new AuthenticationHeaderValue(token) : null,
                }
            };

            return await client.SendAsync(httpRequestMessage);
        }
    }
}