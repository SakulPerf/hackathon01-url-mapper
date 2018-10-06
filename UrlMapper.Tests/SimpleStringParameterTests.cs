using System;
using FluentAssertions;
using Xunit;

namespace UrlMapper.Tests
{
    public class SimpleStringParameterTests
    {
        [Fact]
        public void BuilderCanCreateStringParameterObjectCorrectly()
        {
            var sut = new SimpleStringParameterBuilder();
            var actual = sut.Parse("www.something.com");
            actual.Should().NotBeNull();
        }
    }
}
