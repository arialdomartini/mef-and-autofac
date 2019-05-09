using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Autofac;
using PluginsWithMef.IoC;

namespace PluginsWithMef
{
    public interface IModuleFactory
    {
        Module GetModule();
    }

    public class BaseHost : IDisposable
    {
        private IContainer _container;

        [ImportMany(typeof(IModuleFactory))] private IEnumerable<IModuleFactory> _moduleFactories;

        private static IEnumerable<ComposablePartCatalog> Catalogs =>
            new[]
            {
                new DirectoryCatalog(@"..\..\..\..\Plugin1\bin\Debug\netcoreapp2.0\"),
                new DirectoryCatalog(@"..\..\..\..\Plugin2\bin\Debug\netcoreapp2.0\")
            };

        public void Dispose()
        {
            _container.Dispose();
        }

        public string SomeOperation()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var plugins = scope.Resolve<IEnumerable<IPlugin>>();
                return string.Join("+", plugins.Select(p => p.SomeOperation));
            }
        }

        public void LoadPlugins()
        {
            var moduleFactories = LoadMef();

            _container = BuildContainer(moduleFactories);
        }

        private IContainer BuildContainer(IEnumerable<IModuleFactory> moduleFactories)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<BaseModule>();

            foreach (var moduleFactory in moduleFactories) builder.RegisterModule(moduleFactory.GetModule());

            return builder.Build();
        }

        private IEnumerable<IModuleFactory> LoadMef()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AggregateCatalog(Catalogs));
            new CompositionContainer(catalog).ComposeParts(this);
            return _moduleFactories;
        }
    }
}