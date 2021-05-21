using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Twith.API.Requests.Auth;
using Twith.API.Responses.Auth;
using Twith.API.Test.Helpers;
using Twith.API.Validation;
using Xunit;

namespace Twith.API.Test.Controllers.Auth
{
    public class AuthControllerTest : AbstractApiControllerTest
    {
        public AuthControllerTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }
        
        [Theory]
        [MemberData(nameof(GetInvalidAuthData))]
        public async Task ShouldReturnValidationErrors(SignUpRequest request, IDictionary<string, string> errors)
        {
            var httpResponse = await SendPostAsync("/api/auth/sign-up", request);
            var errorsApiResponse = Deserialize<ValidationErrorsApiResponse>(
                await httpResponse.Content.ReadAsStringAsync()
            );
            
            Assert.Equal(400, errorsApiResponse.Status);

            foreach (var (key, error) in errors)
            {
                Assert.True(errorsApiResponse.Errors.ContainsKey(key));
                Assert.Contains(error, errorsApiResponse.Errors[key]);
            }
        }

        [Fact]
        public async Task ShouldCreateUser()
        {
            var faker = new Faker();

            var request = new SignUpRequest()
            {
                Email = faker.Person.Email,
                Password = "SecurePassword12!",
                LastName = faker.Random.String2(20, 20),
                FirstName = faker.Random.String2(20, 20),
                NickName = faker.Random.String2(15, 15),
            };
            
            var httpResponse = await SendPostAsync("/api/auth/sign-up", request);
            var response = Deserialize<AuthResponse>(
                await httpResponse.Content.ReadAsStringAsync()
            );

            httpResponse.EnsureSuccessStatusCode();
            
            Assert.Equal(request.Email, response.Email);
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.NickName, response.NickName);
            Assert.NotNull(response.Token);
        }
        
        public static IEnumerable<object[]> GetInvalidAuthData()
        {
            var faker = new Faker();
            
            yield return new object[]
            {
                new SignUpRequest(),
                new Dictionary<string, string>()
                {
                    {"email", ValidationErrors.NotBlankError},
                    {"password", ValidationErrors.NotBlankError},
                    {"lastName", ValidationErrors.NotBlankError},
                    {"firstName", ValidationErrors.NotBlankError},
                    {"nickName", ValidationErrors.NotBlankError},
                }
            };
            
            yield return new object[]
            {
                new SignUpRequest()
                {
                    Email = "invalidemail",
                    Password = faker.Random.String2(5, 5),
                    LastName = faker.Random.String2(1, 1),
                    FirstName = faker.Random.String2(1, 1),
                    NickName = faker.Random.String2(4, 4),
                },
                new Dictionary<string, string>()
                {
                    {"email", ValidationErrors.InvalidEmailError},
                    {"password", ValidationErrors.LengthError},
                    {"lastName", ValidationErrors.LengthError},
                    {"firstName", ValidationErrors.LengthError},
                    {"nickName", ValidationErrors.LengthError},
                }
            };
            
            yield return new object[]
            {
                new SignUpRequest()
                {
                    Email = faker.Random.String2(260, 260),
                    Password = faker.Random.String2(21, 21),
                    LastName = faker.Random.String2(105, 105),
                    FirstName = faker.Random.String2(105, 105),
                    NickName = faker.Random.String2(105, 105),
                },
                new Dictionary<string, string>()
                {
                    {"email", ValidationErrors.InvalidEmailError},
                    {"password", ValidationErrors.LengthError},
                    {"lastName", ValidationErrors.LengthError},
                    {"firstName", ValidationErrors.LengthError},
                    {"nickName", ValidationErrors.LengthError},
                }
            };
        }
    }
}