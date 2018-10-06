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

        [Theory(DisplayName = "System can create pattern from segmentation.")]
        [InlineData("", "", "")]
        [InlineData("", " ", "")]
        [InlineData("", null, "")]
        [InlineData(" ", "", "")]
        [InlineData(" ", " ", "")]
        [InlineData(" ", null, "")]
        [InlineData(null, "", "")]
        [InlineData(null, " ", "")]
        [InlineData(null, null, "")]
        [InlineData("www.something.com", "www.something.com", "www.something.com")]
        [InlineData("www.something.com/sakul", "www.something.com/sakul", "www.something.com/sakul")]
        [InlineData("www.something.com/{username}", "www.something.com/sakul", "www.something.com/{username}")]
        [InlineData("www.something.com/{username}/service", "www.something.com/sakul/service", "www.something.com/{username}/service")]
        [InlineData("www.something.com/{username}/service/{service}", "www.something.com/sakul/service/1234", "www.something.com/{username}/service/{service}")]
        [InlineData("{username}", "sakul-jaruthanaset", "{username}")]
        [InlineData("{username}something", "sakulsomething", "{username}something")]
        [InlineData("www.something.com/prefix{username}", "www.something.com/prefixsakul", "www.something.com/prefix{username}")]
        [InlineData("www.something.com/{username}postfix", "www.something.com/sakulpostfix", "www.something.com/{username}postfix")]
        [InlineData("{}", "", "{}")]
        [InlineData("{}", "sakul", "{}")]
        [InlineData("www.something.com/{}", "www.something.com/sakul", "www.something.com/{}")]
        [InlineData("www.something.com/{}", "www.something.com/sakul/something", "www.something.com/{}")]
        [InlineData("{}/{}", "sakul/jaruthanaset", "{}/{}")]
        [InlineData("{}/{}", "sakul/jaruthanaset/123/456", "{}/{}")]
        public void StringParameterCanCreatePatternFromSegmentation(string pattern, string url, string expectedPattern)
        {
            var sut = GetSimpleStringParameterObj(pattern);
            var segments = sut.SegmentPattern(pattern);
            segments.Should().NotBeNull();
            var actual = sut.getPattern(url, segments);
            actual.Should().NotBeNull();
            actual.Should().Be(expectedPattern);
        }

        private SimpleStringParameter GetSimpleStringParameterObj(string pattern)
            => builder.Parse(pattern) as SimpleStringParameter;
    }
}
