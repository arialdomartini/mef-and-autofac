using PluginsWithMef;

namespace Plugin2
{
    public class Plugin2 : IPlugin
    {
        private readonly Collaborator _collaborator;

        public Plugin2(Collaborator collaborator)
        {
            _collaborator = collaborator;
        }

        public string SomeOperation => _collaborator.GetString();
    }
}