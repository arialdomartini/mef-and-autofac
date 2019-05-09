using System.ComponentModel.Composition;
using Autofac;
using PluginsWithMef;

namespace Plugin1
{
    public class Plugin1 : IPlugin
    {
        private BaseCollaborator _baseCollaborator;

        public Plugin1(BaseCollaborator baseCollaborator)
        {
            _baseCollaborator = baseCollaborator;
        }

        public string SomeOperation => $"plugin1 + {_baseCollaborator.GetString()}";
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