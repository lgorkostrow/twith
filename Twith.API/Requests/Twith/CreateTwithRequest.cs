using System.ComponentModel.DataAnnotations;

namespace Twith.API.Requests.Twith
{
    public class CreateTwithRequest
    {
        [Required]
        [StringLength(140)]
        public string? Content { get; set; }
    }
}