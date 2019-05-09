using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace PluginsWithMef
{
    public class BaseHost
    {
        [ImportMany(typeof(IPlugin))] private IEnumerable<IPlugin> _plugins = new List<IPlugin>();

        public string SomeOperation() =>
            string.Join("+", _plugins.Select(p => p.SomeOperation));

        public void LoadPlugins()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\..\Plugin1\bin\Debug\netcoreapp2.0\"));
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\..\Plugin2\bin\Debug\netcoreapp2.0\"));

            new CompositionContainer(catalog).ComposeParts(this);
        }
    }

    public interface IPlugin
    {
        string SomeOperation { get; }
    }
}