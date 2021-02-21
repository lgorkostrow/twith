namespace Twith.Domain.Common.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string entity) : base($"Entity {entity} not found")
        {
        }
    }
}