using System;
using System.Collections.Generic;
using Twith.Domain.Common.Entities;
using Twith.Domain.Twith.Events;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Domain.Twith.Entities
{
    public class Twith : BaseEntity
    {
        public Guid Id { get; }

        public Author Author { get; }

        public Content Content { get; }

        public IList<Like> Likes { get; }

        private int _likesCount;

        private Twith()
        {
            Likes = new List<Like>();
        }

        public Twith(Guid id, Author author, Content content)
        {
            Id = id;
            Author = author;
            Content = content;
            _likesCount = 0;
            
            Likes = new List<Like>();
        }

        public void Like(Author author)
        {
            var like = new Like(Guid.NewGuid(), this, author);
            Likes.Add(like);

            RaiseEvent(new TwithLikedEvent(Id, author.Id, like.Id));
        }
    }
}