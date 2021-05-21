using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.User
{
    public record UpdatePersonalDataCommand : IRequest
    {
        public Guid UserId { get; }

        public string FirstName { get; }
        
        public string LastName { get; }

        public UpdatePersonalDataCommand(Guid userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
    
    public class UpdatePersonalDataHandler : IRequestHandler<UpdatePersonalDataCommand>
    {
        private readonly IUserRepository _repository;

        public UpdatePersonalDataHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePersonalDataCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindOrFailAsync(request.UserId);
            
            user.UpdatePersonalData(new Name(request.FirstName), new Name(request.LastName));

            await _repository.UpdateAsync(user);
            
            return Unit.Value;
        }
    }
}