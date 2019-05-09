using Autofac;

namespace PluginsWithMef.IoC
{
    public class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseCollaborator>();
        }
    }
}