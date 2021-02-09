using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twith.API.Requests.Auth;
using Twith.API.Responses.Auth;
using Twith.Domain.User.Commands;
using Twith.Domain.User.Queries;
using Twith.Infrastructure.Identity;

namespace Twith.API.Controllers.Auth
{
    public class AuthController : ApiControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenClaimsService _tokenClaimsService;

        public AuthController(
            IMediator mediator,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ITokenClaimsService tokenClaimsService
        ) : base(mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenClaimsService = tokenClaimsService;
        }
        
        [HttpPost]
        [Route("sign-in")]
        public async Task<ActionResult<AuthResponse>> SignIn([FromBody] SignInRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);
            if (result.Succeeded)
            {
                var user = await QueryAsync(new GetUserByEmailQuery(request.Email));
                
                return Ok(new AuthResponse(
                    user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.NickName,
                    await _tokenClaimsService.GetTokenAsync(user.Email)
                ));
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<ActionResult<AuthResponse>> SignUp([FromBody] SignUpRequest request)
        {
            var user = new ApplicationUser()
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var command = new CreateUserCommand(
                Guid.Parse(user.Id),
                request.Email,
                request.FirstName,
                request.LastName,
                request.NickName
            );
            await CommandAsync(command);

            return Ok(new AuthResponse(
                Guid.Parse(user.Id),
                request.Email,
                request.FirstName,
                request.LastName,
                request.NickName,
                await _tokenClaimsService.GetTokenAsync(request.Email)
            ));
        }
    }
}