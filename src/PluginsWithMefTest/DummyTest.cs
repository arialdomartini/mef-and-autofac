using FluentAssertions;
using Xunit;

namespace PluginsWithMefTest
{
    public class DummyTest
    {
        [Fact]
        public void should_pass()
        {
            "friends".Should().Be("friends");
        }
    }
}