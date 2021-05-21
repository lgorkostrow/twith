using System.ComponentModel.DataAnnotations;
using Twith.API.Attributes.Validation;

namespace Twith.API.Requests.Auth
{
    public class SignUpRequest
    {
        [Required]
        [StringLength(255, MinimumLength = 10)]
        [EmailAddress]
        [UniqueEmail]
        public string? Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? FirstName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? LastName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 5)]
        [UniqueNickName]
        public string? NickName { get; set; }
    }
}