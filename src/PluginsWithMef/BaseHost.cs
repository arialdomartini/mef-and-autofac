using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace PluginsWithMef
{
    public class BaseHost
    {
        [Import("ProviderName")]
        private string providerName;


        public string SomeOperation()
        {
            if (string.IsNullOrEmpty(providerName))
                return "base";
            return $"base+{providerName}";
        }

        public void LoadPlugins()
        {
            new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly())).ComposeParts(this);
        }
    }
}