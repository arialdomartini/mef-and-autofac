using System.ComponentModel.Composition;
using PluginsWithMef;

namespace Plugin2
{
    [Export(typeof(IPlugin))]
    public class Plugin2 : IPlugin
    {
        public string SomeOperation => "plugin2";
    }

}