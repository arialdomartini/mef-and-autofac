using Autofac;
using PluginsWithMef;

namespace Plugin1.IoC
{
    public class Plugin1Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Plugin1>().As<IPlugin>();
        }
    }
}