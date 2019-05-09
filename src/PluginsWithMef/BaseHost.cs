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
            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(BaseHost).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\..\Plugin1\bin\Debug\netcoreapp2.0\"));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }

    public interface IPlugin
    {
        string SomeOperation { get; }
    }
}