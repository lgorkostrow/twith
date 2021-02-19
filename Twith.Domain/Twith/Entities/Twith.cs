using System;
using System.Collections.Generic;
using System.Linq;
using Twith.Domain.Common.Entities;
using Twith.Domain.Twith.Events;
using Twith.Domain.Twith.Exceptions;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Domain.Twith.Entities
{
    public class Twith : BaseEntity
    {
        public Guid Id { get; }

        public Author Author { get; }

        public Content Content { get; private set; }

        public IList<Like> Likes { get; } = new List<Like>();

        private int _likesCount;

        protected Twith()
        {
        }

        public Twith(Guid id, Author author, Content content)
        {
            Id = id;
            Author = author;
            Content = content;
            _likesCount = 0;
        }

        public void Like(Author author)
        {
            var like = Likes.FirstOrDefault(l => l.Author.Id == author.Id);
            if (like is not null)
            {
                throw new TwithAlreadyLikedException();
            }
            
            like = new Like(Guid.NewGuid(), this, author);
            Likes.Add(like);

            RaiseEvent(new TwithLikedEvent(Id, author.Id, like.Id));
        }

        public void Unlike(Guid userId)
        {
            var like = Likes.FirstOrDefault(l => l.Author.Id == userId);
            if (like is null)
            {
                return;
            }

            Likes.Remove(like);

            RaiseEvent(new TwithUnlikedEvent(Id, userId, like.Id));
        }

        public void Update(Content content)
        {
            Content = content;
        }
    }
}