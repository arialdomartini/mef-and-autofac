using FluentAssertions;
using PluginsWithMef;
using Xunit;

namespace PluginsWithMefTest
{
    public class Plugin1Test
    {
        [Fact]
        public void returns_a_string()
        {
            var plugin1 = new Plugin1.Plugin1(new BaseCollaborator());

            var result = plugin1.SomeOperation;

            result.Should().Be("plugin1 + string provided by base");
        }
    }
}