using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twith.API.Requests.Twith;
using Twith.Domain.Twith.Commands;
using Twith.Domain.Twith.Queries;
using Twith.Infrastructure.Identity;

namespace Twith.API.Controllers.Twith
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TwithController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TwithController(IMediator mediator, UserManager<ApplicationUser> userManager) : base(mediator)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTwithRequest request)
        {
            var command = new CreateTwithCommand(
                Guid.NewGuid(),
                request.Content,
                Guid.Parse(_userManager.GetUserId(this.User))
            );
            
            await CommandAsync(command);

            return Ok(await QueryAsync(new GetTwithQuery(command.Id)));
        }
        
        [HttpPost]
        [Route("{id}/like")]
        public async Task<ActionResult> Like([FromRoute] Guid id)
        {
            var command = new LikeTwithCommand(
                id,
                Guid.Parse(_userManager.GetUserId(this.User))
            );
            
            await CommandAsync(command);

            return Ok(await QueryAsync(new GetTwithQuery(id)));
        }
        
        [HttpPost]
        [Route("{id}/unlike")]
        public async Task<ActionResult> Unlike([FromRoute] Guid id)
        {
            var command = new UnlikeTwithCommand(
                id,
                Guid.Parse(_userManager.GetUserId(this.User))
            );
            
            await CommandAsync(command);

            return Ok(await QueryAsync(new GetTwithQuery(id)));
        }
    }
}