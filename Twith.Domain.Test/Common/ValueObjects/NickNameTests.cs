using System;
using System.Collections.Generic;
using Bogus;
using Xunit;
using Xunit.Extensions;

namespace Twith.Domain.Test.Common.ValueObjects
{
    public class NickNameTests
    {
        public static IEnumerable<object[]> RandomStringsGreaterThan100
        {
            get
            {
                var faker = new Faker();

                return new List<object[]>(new[]
                    {
                        new []{faker.Random.AlphaNumeric(101)},
                        new []{faker.Random.AlphaNumeric(200)},
                    }
                );
            }
        }

        public static IEnumerable<object[]> RandomStringsLessThan100
        {
            get
            {
                var faker = new Faker();

                return new List<object[]>(new[]
                    {
                        new []{faker.Random.AlphaNumeric(100)},
                        new []{faker.Random.AlphaNumeric(50)},
                    }
                );
            }
        }

        [Theory]
        [InlineData("@nick")]
        [InlineData("nick!")]
        [InlineData("nick?")]
        [InlineData("nick*")]
        [InlineData("*nick")]
        [InlineData("@!nick?")]
        public void InvalidInput_ShouldThrowException(string nickName)
        {
            Action a = () => new Domain.Common.ValueObjects.NickName(nickName);

            Assert.Throws<ArgumentException>(a);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyInput_ShouldThrowException(string? nickName)
        {
            Action a = () => new Domain.Common.ValueObjects.NickName(nickName);

            Assert.Throws<ArgumentException>(a);
        }

        [Theory, MemberData(nameof(RandomStringsGreaterThan100))]
        public void NickNameGreaterThan100_ShouldThrowException(string nickName)
        {
            Action a = () => new Domain.Common.ValueObjects.NickName(nickName);

            Assert.Throws<ArgumentException>(a);
        }

        [Theory, MemberData(nameof(RandomStringsLessThan100))]
        public void NickNameLessThan100_ShouldCreateObject(string nickName)
        { 
            var nickNameObject = new Domain.Common.ValueObjects.NickName(nickName);
            
            Assert.Equal(nickName, nickNameObject.Value);
        }
    }
}