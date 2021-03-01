using System;
using Bogus;
using Xunit;

namespace Twith.Domain.Test.User.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyInput_ShouldThrowException(string? email)
        {
            Action a = () => new Domain.User.ValueObjects.Email(email);

            Assert.Throws<ArgumentException>(a);
        }
        
        [Fact]
        public void InputGreaterThan255_ShouldThrowException()
        {
            var faker = new Faker();
            
            Action a = () => new Domain.User.ValueObjects.Email(faker.Random.String2(256, 256));

            Assert.Throws<ArgumentException>(a);
        }
        
        [Theory]
        [InlineData("email")]
        [InlineData("email@")]
        public void InvalidInput_ShouldThrowException(string email)
        {
            Action a = () => new Domain.User.ValueObjects.Email(email);
            
            Assert.Throws<ArgumentException>(a);
        }
        
        [Theory]
        [InlineData("email@gmail.com")]
        [InlineData("email@yandex.ru")]
        [InlineData("email@mail.ru")]
        [InlineData("email12@gmail.com")]
        [InlineData("Te12asd@gmail.com")]
        public void ValidNames_ShouldCreateObject(string email)
        { 
            var emailObject = new Domain.User.ValueObjects.Email(email);
            
            Assert.Equal(email, emailObject.Value);
        }
    }
}