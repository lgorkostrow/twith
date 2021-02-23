using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Twith.API.Requests
{
    public record BaseListRequest
    {
        [FromQuery(Name = "_limit")]
        [Range(0, 30)]
        public int Limit { get; set; } = 15;

        [FromQuery(Name = "_offset")]
        [Range(0, int.MaxValue)]

        public int Offset { get; set; } = 0;
    }
}