using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Twith.API.Validation
{
    public class ApiValidationMetadataProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                if (attribute is not ValidationAttribute validationAttribute)
                {
                    continue;       
                }

                validationAttribute.ErrorMessage = ValidationErrors.MapAttributeToConstant(validationAttribute);
            }
        }
    }
}