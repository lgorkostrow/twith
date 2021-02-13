using System;
using System.Collections.Generic;
using Bogus;
using Xunit;

namespace Twith.Domain.Test.Common.ValueObjects
{
    public class NameTests
    {
        public static IEnumerable<object[]> NamesGreaterThan100
        {
            get
            {
                var faker = new Faker();

                return new List<object[]>(new[]
                    {
                        new []{faker.Random.String2(101, 101)},
                        new []{faker.Random.String2(110, 200)},
                    }
                );
            }
        }
        
        public static IEnumerable<object[]> ValidNames
        {
            get
            {
                var faker = new Faker();

                return new List<object[]>(new[]
                    {
                        new []{faker.Name.FirstName()},
                        new []{faker.Name.LastName()},
                    }
                );
            }
        }
        
        [Theory]
        [InlineData("Vasya Pupkin")]
        [InlineData("Vasya12")]
        public void InvalidInput_ShouldThrowException(string name)
        {
            Action a = () => new Domain.Common.ValueObjects.Name(name);
            
            Assert.Throws<ArgumentException>(a);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyInput_ShouldThrowException(string? name)
        {
            Action a = () => new Domain.Common.ValueObjects.Name(name);

            Assert.Throws<ArgumentException>(a);
        }
        
        [Theory, MemberData(nameof(NamesGreaterThan100))]
        public void NameGreaterThan100_ShouldThrowException(string name)
        {
            Action a = () => new Domain.Common.ValueObjects.Name(name);

            Assert.Throws<ArgumentException>(a);
        }
        
        [Theory, MemberData(nameof(ValidNames))]
        [InlineData("O'Connell")]
        public void ValidNames_ShouldCreateObject(string name)
        { 
            var nameObject = new Domain.Common.ValueObjects.Name(name);
            
            Assert.Equal(name, nameObject.Value);
        }
    }
}