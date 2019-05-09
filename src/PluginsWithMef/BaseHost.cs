using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Autofac;
using Autofac.Integration.Mef;

namespace PluginsWithMef
{
    public class BaseHost : IDisposable
    {
        private IContainer _container;
        private ILifetimeScope _scope;

        public string SomeOperation()
        {
            var plugins = _scope.Resolve<IEnumerable<IPlugin>>();
            return string.Join("+", plugins.Select(p => p.SomeOperation));
        }

        public void LoadPlugins()
        {
            var builder = new ContainerBuilder();
            builder.RegisterComposablePartCatalog(new DirectoryCatalog(@"..\..\..\..\Plugin1\bin\Debug\netcoreapp2.0\"));
            builder.RegisterComposablePartCatalog(new DirectoryCatalog(@"..\..\..\..\Plugin2\bin\Debug\netcoreapp2.0\"));
            _container = builder.Build();
            _scope = _container.BeginLifetimeScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
            _container.Dispose();
        }
    }

    public interface IPlugin
    {
        string SomeOperation { get; }
    }
}