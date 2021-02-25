using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twith.API.Requests.User;
using Twith.Domain.User.Commands;
using Twith.Domain.User.Dtos;
using Twith.Domain.User.Queries;
using Twith.Infrastructure.Identity;

namespace Twith.API.Controllers.User
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Updates current user personal data
        /// </summary>
        /// <returns>UserDetailedViewDto</returns>
        [HttpPut]
        public async Task<ActionResult<UserDetailedViewDto>> UpdatePersonalData(
            [FromBody] UpdatePersonalDataRequest request)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var command = new UpdatePersonalDataCommand(
                userId,
                request.FirstName,
                request.LastName
            );

            await CommandAsync(command);

            return Ok(await QueryAsync(new GetUserQuery(userId)));
        }
    }
}