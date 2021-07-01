using System;
using Twith.Domain.Common.ValueObjects;

namespace Twith.Domain.Twith.ValueObjects
{
    public record Content : BaseValueObject
    {
        public string Value { get; }

        public Content(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > 140)
            {
                throw new ArgumentException(nameof(value));
            } 
            
            Value = value;
        }
    }
}