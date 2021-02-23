using System;
using Bogus;
using Xunit;

namespace Twith.Domain.Test.Twith.ValueObjects
{
    public class ContentTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyInput_ShouldThrowException(string? content)
        {
            Action a = () => new Domain.Twith.ValueObjects.Content(content);

            Assert.Throws<ArgumentException>(a);
        }

        [Fact]
        public void InputGreaterThan140_ShouldThrowException()
        {
            var faker = new Faker();
            
            Action a = () => new Domain.Twith.ValueObjects.Content(faker.Lorem.Sentences(10));

            Assert.Throws<ArgumentException>(a);
        }
    }
}