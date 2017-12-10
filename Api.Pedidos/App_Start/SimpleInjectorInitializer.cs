using System;
using System.Collections.Generic;
using System.Linq;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using WebActivatorEx;
using SimpleInjector.Integration.WebApi;
using Api.Pedidos.App_Start;
using Infra.CrossCutting.IoC.loC;
using System.Web.Http;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace Api.Pedidos.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}