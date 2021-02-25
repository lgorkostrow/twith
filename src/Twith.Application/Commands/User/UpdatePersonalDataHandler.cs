using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.User.Commands;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.User
{
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