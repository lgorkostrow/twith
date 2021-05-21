using System;
using System.ComponentModel.DataAnnotations;
using Twith.API.Attributes.Validation;

namespace Twith.API.Validation
{
    public static class ValidationErrors
    {
        public static string NotBlankError => "NOT_BLANK_ERROR";
        public static string NotUniqueError => "NOT_UNIQUE_ERROR";
        public static string LengthError => "LENGTH_ERROR";
        public static string InvalidEmailError => "INVALID_EMAIL_ERROR";

        public static string MapAttributeToConstant(ValidationAttribute attribute)
        {
            switch (attribute)
            {
                case RequiredAttribute:
                    return NotBlankError;
                case EmailAddressAttribute:
                    return InvalidEmailError;
                case UniqueEmailAttribute:
                case UniqueNickNameAttribute:
                    return NotUniqueError;
                case StringLengthAttribute:
                case MinLengthAttribute:
                case MaxLengthAttribute:
                    return LengthError;
                default:
                    throw new ArgumentException("Attribute not implemented", attribute.GetType().Name);
            }
        }
    }
}