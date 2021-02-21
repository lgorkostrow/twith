using MediatR;

namespace Twith.Domain.User.Queries
{
    public record IsUserWithNickNameExistsQuery : IRequest<bool>
    {
        public string NickName { get; }
        
        public IsUserWithNickNameExistsQuery(string nickName)
        {
            NickName = nickName;
        }
    }
}