using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.User.Factories;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.User
{
    public record CreateUserCommand : IRequest
    {
        public Guid Id { get; }
        
        public string Email { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }
        
        public string NickName { get; }

        public CreateUserCommand(Guid id, string email, string firstName, string lastName, string nickName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
    
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.SaveAsync(
                UserFactory.Create(request.Id, request.Email, request.FirstName, request.LastName, request.NickName)
            );

            return Unit.Value;
        }
    }
}