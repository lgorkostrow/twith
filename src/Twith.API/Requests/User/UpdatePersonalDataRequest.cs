using System.ComponentModel.DataAnnotations;

namespace Twith.API.Requests.User
{
    public record UpdatePersonalDataRequest
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
    }
}