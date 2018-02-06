using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using TesteTecnico.Infrastructure;
using TesteTecnico.Persistency.Mock;
using TesteTecnico.Application.Installers;

namespace TesteTecnico.Presentation.Windsor
{
    public static class WindsorBootstrap
    {
        public static IWindsorContainer Start()
        {
            var container = Factory.Instance.Container;

            RegisterAllInstalers(container);

            return container;
        }

        private static void RegisterAllInstalers(IWindsorContainer container)
        {
            container.Install(new ApplicationInstaller());
            container.Install(new PersistencyInstaller());
        }
    }
}
