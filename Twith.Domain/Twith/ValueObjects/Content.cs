namespace Twith.Domain.Twith.ValueObjects
{
    public record Content
    {
        public string Value { get; }

        public Content(string value)
        {
            Value = value;
        }
    }
}