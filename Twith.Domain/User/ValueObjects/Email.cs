namespace Twith.Domain.User.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            Value = value;
        }
    }
}