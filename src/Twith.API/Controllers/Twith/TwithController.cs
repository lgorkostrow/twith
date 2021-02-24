﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twith.API.Attributes.Authorization;
using Twith.API.Authorizations.Handlers;
using Twith.API.Requests.Twith;
using Twith.API.Responses;
using Twith.Domain.Twith.Commands;
using Twith.Domain.Twith.Dtos;
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

        [HttpGet]
        public async Task<ActionResult<ListResponse<TwithListViewDto>>> GetList([FromQuery] GetTwithListRequest request)
        {
            var query = new GetTwithsListQuery(
                request.Limit,
                request.Offset,
                Guid.Parse(_userManager.GetUserId(User))
            );

            return Ok(
                new ListResponse<TwithListViewDto>(await QueryAsync(query))
            );
        }

        [HttpPost]
        public async Task<ActionResult<TwithDetailedViewDto>> Create([FromBody] CreateTwithRequest request)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            var command = new CreateTwithCommand(
                Guid.NewGuid(),
                request.Content,
                userId
            );

            await CommandAsync(command);

            return Ok(await QueryAsync(new GetTwithQuery(command.Id, userId)));
        }

        [HttpPost]
        [Route("{id}/like")]
        public async Task<ActionResult<TwithDetailedViewDto>> Like([FromRoute] Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            await CommandAsync(new LikeTwithCommand(id, userId));

            return Ok(await QueryAsync(new GetTwithQuery(id, userId)));
        }

        [HttpPost]
        [Route("{id}/unlike")]
        public async Task<ActionResult<TwithDetailedViewDto>> Unlike([FromRoute] Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            await CommandAsync(new UnlikeTwithCommand(id, userId));

            return Ok(await QueryAsync(new GetTwithQuery(id, userId)));
        }

        [HttpPut]
        [Route("{id}")]
        [AuthorizeResource(typeof(SameAuthorRequirement))]
        public async Task<ActionResult<TwithDetailedViewDto>> Update([FromRoute] Guid id,
            [FromBody] UpdateTwithRequest request)
        {
            await CommandAsync(new UpdateTwithCommand(id, request.Content));

            return Ok(await QueryAsync(new GetTwithQuery(id, Guid.Parse(_userManager.GetUserId(User)))));
        }

        [HttpDelete]
        [Route("{id}")]
        [AuthorizeResource(typeof(SameAuthorRequirement))]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await CommandAsync(new DeleteTwithCommand(id));

            return NoContent();
        }

        [HttpGet]
        [Route("{id}/likes")]
        public async Task<ActionResult<ListResponse<LikeDto>>> GetTwithLikes([FromRoute] Guid id,
            [FromQuery] GetTwithLikesRequest request)
        {
            var likes = await QueryAsync(new GetTwithLikesQuery(request.Limit, request.Offset, id));

            return Ok(new ListResponse<LikeDto>(likes));
        }
    }
}