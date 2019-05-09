using System.ComponentModel.Composition;

namespace PluginsWithMef
{
    [Export(typeof(IPlugin))]
    public class Plugin1 : IPlugin
    {
        public string SomeOperation => "plugin1";
    }
}