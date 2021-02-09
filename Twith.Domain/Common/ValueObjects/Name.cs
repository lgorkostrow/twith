namespace Twith.Domain.Common.ValueObjects
{
    public record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
        }
    }
}