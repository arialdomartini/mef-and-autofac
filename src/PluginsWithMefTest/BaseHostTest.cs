using FluentAssertions;
using PluginsWithMef;
using Xunit;

namespace PluginsWithMefTest
{
    public class BaseHostTest
    {
        [Fact]
        public void should_use_all_the_available_plugins()
        {
            using (var baseHost = new BaseHost())
            {
                baseHost.LoadPlugins();

                var result = baseHost.SomeOperation();

                result.Should().Contain("plugin1 + string provided by base");
                result.Should().Contain("plugin2");
            }
        }
    }
}