using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.User.Commands;
using Twith.Domain.User.Factories;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.User
{
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
                UserFactory.create(request.Id, request.Email, request.FirstName, request.LastName, request.NickName)
            );

            return Unit.Value;
        }
    }
}