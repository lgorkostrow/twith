using System;

namespace Twith.API.Responses.Auth
{
    public record AuthResponse
    {
        public Guid Id { get; }
        
        public string Email { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }
        
        public string NickName { get; }
        
        public string Token { get; }

        public AuthResponse(Guid id, string email, string firstName, string lastName, string nickName, string token)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Token = token;
        }
    }
}