using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace PluginsWithMef
{
    public class BaseHost
    {
        [Import(typeof(IPlugin))] private IPlugin _plugin;


        public string SomeOperation()
        {
            if (_plugin == null)
                return "base";
            return $"base+{_plugin.SomeOperation}";
        }

        public void LoadPlugins()
        {
            new CompositionContainer(
                    new AssemblyCatalog(
                        Assembly.GetExecutingAssembly()))
                .ComposeParts(this);
        }
    }

    public interface IPlugin
    {
        string SomeOperation { get; }
    }
}