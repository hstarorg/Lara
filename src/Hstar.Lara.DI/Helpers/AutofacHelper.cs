using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Hstar.Lara.DI.Helpers
{
    public static class AutofacHelper
    {
        public static IContainer ApplicationContainer { get; private set; }

        private static IList<Type> GetApplicationTypes()
        {
            // Get all assembly and types.
            var deps = DependencyContext.Default;
            var typeList = new List<Type>();
            deps.CompileLibraries
                // Ignore all system assembly and nuget pakage
                .Where(lib => !lib.Serviceable && lib.Type != "package")
                .ToList().ForEach(lib =>
                {
                    try
                    {
                        var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                        typeList.AddRange(assembly.GetTypes().Where(type => type != null));
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Load deps error.", e);
                    }
                });
            return typeList;
        }

        private static void RegisterTypes(ContainerBuilder builder, IList<AutoRegisterAttribute> types, ServiceLifetime lifetime, bool asSelf = false)
        {
            var findTypes = types.Where(x => x.Lifetime == lifetime && x.AsSelf == asSelf).Select(x => x.ServiceType).ToArray();
            var typeBuilder = builder.RegisterTypes(findTypes)
                .PropertiesAutowired();
            if (asSelf)
            {
                typeBuilder.AsSelf();
            }
            else
            {
                typeBuilder.AsImplementedInterfaces();
            }
            switch (lifetime)
            {
                case ServiceLifetime.Scoped:
                    typeBuilder.InstancePerDependency();
                    break;

                case ServiceLifetime.Singleton:
                    typeBuilder.SingleInstance();
                    break;

                case ServiceLifetime.Transient:
                    typeBuilder.InstancePerLifetimeScope();
                    break;
            }
        }

        public static IServiceProvider BuildServiceProvider(IServiceCollection services, params IModule[] modules)
        {
            var builder = new ContainerBuilder();
            // Register modules
            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }
            // Get all types
            var types = GetApplicationTypes();
            types.Select(t => new { Type = t, AutoRegister = t.GetCustomAttribute<AutoRegisterAttribute>(true) })
                .Where(x => x.AutoRegister != null)
                .Select(x =>
                {
                    if (x.AutoRegister.ServiceType == null)
                    {
                        x.AutoRegister.ServiceType = x.Type;
                    }
                    return x.AutoRegister;
                })
                .GroupBy(x => x.Lifetime)
                .Select(g =>
             new
             {
                 g.Key,
                 TypeList = g.ToList()
             })
             .ToList()
             .ForEach(item =>
             {
                 // Register as implemented interfaces
                 RegisterTypes(builder, item.TypeList, item.Key, false);
                 // Register as self
                 RegisterTypes(builder, item.TypeList, item.Key, true);
             });

            builder.Populate(services);
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        /// <summary>
        /// Dispose container
        /// </summary>
        public static void DisposeContainer()
        {
            ApplicationContainer.Dispose();
        }
    }
}