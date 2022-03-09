using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GrupoCiencias.Intranet.CrossCutting.IoC.Container
{
    public class IoCAutofacContainer
    {
        private static IContainer container;
        protected static readonly Lazy<IoCAutofacContainer> instance = new Lazy<IoCAutofacContainer>(() => new IoCAutofacContainer(), true);


        public static IoCAutofacContainer Current
        {
            get { return instance.Value; }
        }
        public static IContainer Initialize(IServiceCollection services)
        {

            ContainerBuilder builder;
            try
            {
                builder = new ContainerBuilder();
                builder.Populate(services);


                string[] assemblyScanerPattern = new[] {
                    "GrupoCiencias.Intranet.Application.*.dll",
                    "GrupoCiencias.Intranet.Domain.*.dll",
                    "GrupoCiencias.Intranet.Repository.*.dll"
                };

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                List<Assembly> assemblies = new List<Assembly>();
                assemblies.AddRange(
                    Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
                             .Where(filename => assemblyScanerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                             .Select(Assembly.LoadFrom)
                    );

                foreach (var assembly in assemblies)
                    builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

                container = builder.Build();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            return container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        public T Resolve<T>(string name, object value)
        {
            return container.Resolve<T>(new NamedParameter(name, value));
        }
    }
}
