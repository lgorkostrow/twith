using System;

namespace Twith.Domain.User.Dtos
{
    public record UserDetailedViewDto
    {
        public Guid Id { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public string NickName { get; }

        public UserDetailedViewDto(Guid id, string email, string firstName, string lastName, string nickName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
}