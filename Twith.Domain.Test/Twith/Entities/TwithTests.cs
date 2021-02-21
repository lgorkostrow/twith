using System;
using Bogus;
using Twith.Domain.Twith.Events;
using Twith.Domain.Twith.Exceptions;
using Twith.Domain.Twith.ValueObjects;
using Twith.Test.Helpers;
using Twith.Test.Helpers.Extensions;
using Xunit;

namespace Twith.Domain.Test.Twith.Entities
{
    public class TwithTests : ITest
    {
        private readonly Faker _faker;

        public TwithTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ShouldAddLikeToTwith()
        {
            var twith = this.CreateTwith(_faker);
            var author = this.CreateAuthor(_faker);

            Assert.Equal(0, twith.Likes.Count);
            Assert.Equal(0, twith.DomainEvents.Count);
            
            twith.Like(author);
            
            Assert.Equal(1, twith.Likes.Count);
            Assert.Equal(1, twith.DomainEvents.Count);
            Assert.Contains(twith.Likes, l => l.Author.Id == author.Id);
            Assert.Contains(twith.DomainEvents, e => e is TwithLikedEvent);
        }

        [Fact]
        public void ShouldThrowTwithAlreadyLikedException()
        {
            var twith = this.CreateTwith(_faker);
            var author = this.CreateAuthor(_faker);

            twith.Like(author);

            Assert.Throws<TwithAlreadyLikedException>(() => twith.Like(author));
        }

        [Fact]
        public void ShouldRemoveLikeFromTwith()
        {
            var twith = this.CreateTwith(_faker);
            var author = this.CreateAuthor(_faker);

            Assert.Equal(0, twith.DomainEvents.Count);
            
            twith.Like(author);
            
            Assert.Equal(1, twith.Likes.Count);
            Assert.Equal(1, twith.DomainEvents.Count);
            
            twith.Unlike(author.Id);
            
            Assert.Equal(0, twith.Likes.Count);
            Assert.Equal(2, twith.DomainEvents.Count);
            Assert.Contains(twith.DomainEvents, e => e is TwithUnlikedEvent);
        }

        [Fact]
        public void ShouldNotFindLike()
        {
            var twith = this.CreateTwith(_faker);
            var author = this.CreateAuthor(_faker);

            twith.Like(author);
            
            twith.Unlike(Guid.NewGuid());
            
            Assert.Equal(1, twith.Likes.Count);
            Assert.Equal(1, twith.DomainEvents.Count);
            Assert.DoesNotContain(twith.DomainEvents, e => e is TwithUnlikedEvent);
        }

        [Fact]
        public void ShouldUpdateContent()
        {
            var twith = this.CreateTwith(_faker);
            var content = new Content(_faker.Lorem.Sentences(1));

            twith.Update(content);
            
            Assert.Equal(content, twith.Content);
        }
    }
}