using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Autofac;

namespace PluginsWithMef
{
    public interface IModuleFactory
    {
        Module GetModule();
    }

    public class BaseHost : IDisposable
    {
        private IContainer _container;
        private ILifetimeScope _scope;

        [ImportMany(typeof(IModuleFactory))]
        private IEnumerable<IModuleFactory> _moduleFactories;

        public string SomeOperation()
        {
            var plugins = _scope.Resolve<IEnumerable<IPlugin>>();
            return string.Join("+", plugins.Select(p => p.SomeOperation));
        }

        public void LoadPlugins()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\..\Plugin1\bin\Debug\netcoreapp2.0\"));
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\..\Plugin2\bin\Debug\netcoreapp2.0\"));

            new CompositionContainer(catalog).ComposeParts(this);

            var builder = new ContainerBuilder();

            foreach (var moduleFactory in _moduleFactories)
            {
                builder.RegisterModule(moduleFactory.GetModule());
            }
            _container = builder.Build();
            _scope = _container.BeginLifetimeScope();
        }

        public void Dispose()
        {
            //_scope.Dispose();
//            _container.Dispose();
        }
    }

    public interface IPlugin
    {
        string SomeOperation { get; }
    }
}