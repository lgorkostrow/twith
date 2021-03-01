using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Twith.API.Requests.Auth;
using Twith.API.Test.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Twith.API.Test.Controllers.Auth
{
    public class AuthControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _testOutputHelper;

        public AuthControllerTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Test()
        {
            var client = _factory.CreateClient();

            var httpResponse = await client.PostAsJsonAsync("/api/auth/sign-up", new SignUpRequest() {Email = "test"});
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            // httpResponse.EnsureSuccessStatusCode();
            
            var obj = JsonConvert.DeserializeObject<ValidationErrorsApiResponse>(httpResponse.Content.ReadAsStringAsync().Result);
            
            _testOutputHelper.WriteLine(obj.Type);
        }
    }
}