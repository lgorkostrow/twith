namespace Twith.Domain.Common.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}