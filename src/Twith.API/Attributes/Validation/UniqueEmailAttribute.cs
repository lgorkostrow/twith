using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Twith.API.Validation;
using Twith.Domain.User.Queries;
using Twith.Identity.Repositories;

namespace Twith.API.Attributes.Validation
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            var mediator = validationContext.GetService<IMediator>() ?? throw new NoNullAllowedException();
            var applicationUserRepository = validationContext.GetService<IApplicationUserRepository>() ?? throw new NoNullAllowedException();
    
            async Task<bool> IsUserWithEmailExists()
            {
                var taskList = new List<Task<bool>>
                {
                    mediator.Send(new IsUserWithEmailExistsQuery((string) value)),
                    applicationUserRepository.IsUserWithEmailExistsAsync((string) value)
                };


                return (await Task.WhenAll(taskList)).Contains(true);
            }

            var result = Task
                .Run(IsUserWithEmailExists)
                .Result;

            return result
                ? new ValidationResult(ValidationErrors.NotUniqueError)
                : ValidationResult.Success;
        }
    }
}