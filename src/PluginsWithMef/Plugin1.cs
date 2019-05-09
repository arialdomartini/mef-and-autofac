using System.ComponentModel.Composition;

namespace Plugin1
{
    public class Plugin1
    {
        [Export("ProviderName")] public string SomeOperation => "plugin1";
    }
}