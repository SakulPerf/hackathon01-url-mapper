using System;
using FluentAssertions;
using Xunit;

namespace UrlMapper.Tests
{
    public class SimpleStringParameterTests
    {
        private SimpleStringParameterBuilder builder;

        public SimpleStringParameterTests()
            => builder = new SimpleStringParameterBuilder();

        [Theory(DisplayName = "Send any string to the builder it alway return object.")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("www.something.com")]
        [InlineData("www.something.com/{username}")]
        public void BuilderCanCreateStringParameterObjectCorrectly(string pattern)
        {
            var sut = builder;
            var actual = sut.Parse(pattern);
            actual.Should().NotBeNull();
        }

        [Theory(DisplayName = "System can segment any patterns.")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("www.something.com", "www.something.com")]
        [InlineData("www.something.com/sakul", "www.something.com/sakul")]
        [InlineData("www.something.com/{username}", "www.something.com/", "{username}")]
        [InlineData("www.something.com/{username}/service", "www.something.com/", "{username}", "/service")]
        [InlineData("www.something.com/{username}/service/{service}", "www.something.com/", "{username}", "/service/", "{service}")]
        [InlineData("{username}", "{username}")]
        [InlineData("{username}something", "{username}", "something")]
        [InlineData("www.something.com/prefix{username}", "www.something.com/prefix", "{username}")]
        [InlineData("www.something.com/{username}postfix", "www.something.com/", "{username}", "postfix")]
        [InlineData("{}", "{}")]
        [InlineData("www.something.com/{}", "www.something.com/", "{}")]
        [InlineData("{}/{}", "{}", "/", "{}")]
        public void StringParameterCanSegmentAnyPattern(string pattern, params string[] expectedSegments)
        {
            var sut = GetSimpleStringParameterObj(pattern);
            var actual = sut.SegmentPattern(pattern);
            actual.Should().NotBeNull().And.BeEquivalentTo(expectedSegments);
        }

        private SimpleStringParameter GetSimpleStringParameterObj(string pattern)
            => builder.Parse(pattern) as SimpleStringParameter;
    }
}
