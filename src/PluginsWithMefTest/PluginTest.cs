using FluentAssertions;
using PluginsWithMef;
using Xunit;

namespace PluginsWithMefTest
{
    public class PluginTest
    {
        [Fact]
        public void returns_a_string()
        {
            var plugin1 = new Plugin1.Plugin1();

            var result = plugin1.SomeOperation;

            result.Should().Be("plugin1");
        }
    }
}