using System;
using System.ComponentModel.DataAnnotations;

namespace Twith.API.Requests.Auth
{
    public class SignUpRequest
    {
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string? Password { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? NickName { get; set; }
    }
}