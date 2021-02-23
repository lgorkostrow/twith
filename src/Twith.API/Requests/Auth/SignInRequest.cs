using System.ComponentModel.DataAnnotations;

namespace Twith.API.Requests.Auth
{
    public class SignInRequest
    {
        [Required]
        public string? Email { get; set; }
        
        [Required]
        public string? Password { get; set; }
    }
}