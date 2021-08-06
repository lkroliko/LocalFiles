using Xunit;
using LocalFiles.Core.Extensions;
using FluentAssertions;

namespace LocalFiles.UnitTests
{
    [Trait("Category", "Extensions")]
    public class StringExtensionTests
    {
        [Fact]
        public void WhenCalledThenDecoded()
        {
            string value = "localfile://test+\u0026";

            var result = value.ToPath();

            result.Should().Be("test &");
        }
    }
}
