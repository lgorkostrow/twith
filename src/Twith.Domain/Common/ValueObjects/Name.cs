using System;
using System.Text.RegularExpressions;

namespace Twith.Domain.Common.ValueObjects
{
    public record Name : BaseValueObject
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > 100)
            {
                throw new ArgumentException(nameof(value));
            } 
            
            var match = Regex.Match(value, "^[a-zA-Z']+$", RegexOptions.Multiline);
            if (!match.Success)
            {
                throw new ArgumentException(nameof(value));
            }
            
            Value = value;
        }
    }
}