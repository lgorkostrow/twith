namespace Twith.Domain.Common.ValueObjects
{
    public record NickName
    {
        public string Value { get; }

        public NickName(string value)
        {
            Value = value;
        }
    }
}