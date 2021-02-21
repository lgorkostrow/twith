﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Twith.Domain.User.Queries;

namespace Twith.API.Attributes.Validation
{
    public class UniqueNickName : ValidationAttribute
    {
        public string GetErrorMessage() => "NickName is not unique";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            var mediator = validationContext.GetService<IMediator>();
            var result = Task
                .Run(async () => await mediator.Send(new IsUserWithNickNameExistsQuery((string) value)))
                .Result;

            return result
                ? new ValidationResult(GetErrorMessage())
                : ValidationResult.Success;
        }
    }
}