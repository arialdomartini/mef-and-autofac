﻿using System.ComponentModel.Composition;
using PluginsWithMef;

namespace Plugin1
{
    [Export(typeof(IPlugin))]
    public class Plugin1 : IPlugin
    {
        public string SomeOperation => "plugin1";
    }
}