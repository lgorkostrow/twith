using System;
using System.ComponentModel.DataAnnotations;

namespace Twith.Domain.User.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > 255)
            {
                throw new ArgumentException(nameof(value));
            }

            var attribute = new EmailAddressAttribute();
            if (!attribute.IsValid(value))
            {
                throw new ArgumentException(nameof(value));
            }
            
            Value = value;
        }
    }
}