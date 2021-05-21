using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Twith.Application.Queries.Twith;

namespace Twith.API.Authorizations.Handlers
{
    public class SameTwithAuthorAuthorizationHandler :
        AuthorizationHandler<SameAuthorRequirement, Guid>
    {
        private readonly IMediator _mediator;

        public SameTwithAuthorAuthorizationHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            SameAuthorRequirement requirement,
            Guid twithId
        )
        {
            var twithAuthor = await _mediator.Send(new GetTwithAuthorQuery(twithId));
            if (Guid.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier)) == twithAuthor.Id)
            {
                context.Succeed(requirement);
                
                return;
            }
            
            context.Fail();
        }
    }
    
    public class SameAuthorRequirement : IAuthorizationRequirement {}
}