using System.ComponentModel.Composition;
using Autofac;
using PluginsWithMef;

namespace Plugin1.IoC
{
    [Export(typeof(IModuleFactory))]
    public class ModuleFactory : IModuleFactory
    {
        public Module GetModule()
        {
            return new Plugin1Module();
        }
    }
}