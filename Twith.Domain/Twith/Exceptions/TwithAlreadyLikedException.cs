using Twith.Domain.Common.Exceptions;

namespace Twith.Domain.Twith.Exceptions
{
    public class TwithAlreadyLikedException : DomainException
    {
        private new const string Message = "TWITH_ALREADY_LIKED";
        public TwithAlreadyLikedException() : base(Message)
        {
        }
    }
}