using FluentAssertions;
using PluginsWithMef;
using Xunit;

namespace PluginsWithMefTest
{
    public class BaseHostTest
    {
        [Fact]
        public void no_plugins_case()
        {
            var baseHost = new BaseHost();
            var result = baseHost.SomeOperation();

            result.Should().Be("base");
        }
    }
}