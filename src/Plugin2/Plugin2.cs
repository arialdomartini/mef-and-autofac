using System.ComponentModel.Composition;
using Autofac;
using PluginsWithMef;

namespace Plugin2
{
    public class Plugin2 : IPlugin
    {
        private Collaborator _collaborator;

        public Plugin2(Collaborator collaborator)
        {
            _collaborator = collaborator;
        }

        public string SomeOperation => _collaborator.GetString();
    }


    public class Collaborator
    {
        public string GetString() => "plugin2";
    }
    [Export(typeof(IModuleFactory))]
    public class Factory : IModuleFactory
    {
        public Module GetModule()
        {
            return new Plugin2Module();
        }
    }

    public class Plugin2Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Plugin2>().As<IPlugin>();
            builder.RegisterType<Collaborator>().AsSelf();
        }
    }
}