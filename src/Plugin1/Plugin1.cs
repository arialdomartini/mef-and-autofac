using System.ComponentModel.Composition;
using Autofac;
using PluginsWithMef;

namespace Plugin1
{
    public class Plugin1 : IPlugin
    {
        public string SomeOperation => "plugin1";
    }

    [Export(typeof(IModuleFactory))]
    public class Factory : IModuleFactory
    {
        public Module GetModule()
        {
            return new Plugin1Module();
        }
    }

    public class Plugin1Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Plugin1>().As<IPlugin>();
        }


    }
}