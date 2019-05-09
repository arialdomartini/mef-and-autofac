using Autofac;
using PluginsWithMef;

namespace Plugin2.IoC
{
    public class Plugin2Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Plugin2>().As<IPlugin>();
            builder.RegisterType<Collaborator>().AsSelf();
        }
    }
}