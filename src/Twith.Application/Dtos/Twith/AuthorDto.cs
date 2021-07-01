using System;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Application.Dtos.Twith
{
    public record AuthorDto : BaseDto
    {
        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public string NickName { get; }

        public AuthorDto(Guid id, string firstName, string lastName, string nickName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }

        public AuthorDto(Author author) : this(
            author.Id,
            author.FirstName.Value,
            author.LastName.Value,
            author.NickName.Value
        )
        {
        }
    }
}