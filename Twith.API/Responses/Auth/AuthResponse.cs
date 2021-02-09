using System;

namespace Twith.API.Responses.Auth
{
    public record AuthResponse
    {
        public Guid Id { get; }
        
        public string Email { get; }
        
        public string Token { get; }

        public AuthResponse(Guid id, string email, string token)
        {
            Id = id;
            Email = email;
            Token = token;
        }
    }
}