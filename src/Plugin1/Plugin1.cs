using PluginsWithMef;

namespace Plugin1
{
    public class Plugin1 : IPlugin
    {
        private readonly BaseCollaborator _baseCollaborator;

        public Plugin1(BaseCollaborator baseCollaborator)
        {
            _baseCollaborator = baseCollaborator;
        }

        public string SomeOperation => $"plugin1 + {_baseCollaborator.GetString()}";
    }
}