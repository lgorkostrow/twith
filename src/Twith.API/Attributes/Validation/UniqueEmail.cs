using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Twith.Domain.User.Queries;
using Twith.Infrastructure.Identity;

namespace Twith.API.Attributes.Validation
{
    public class UniqueEmail : ValidationAttribute
    {
        public string GetErrorMessage() => "Email is not unique";

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
                ? new ValidationResult(GetErrorMessage())
                : ValidationResult.Success;
        }
    }
}