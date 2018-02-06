using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace TesteTecnico.Persistency.Mock
{
    public class PersistencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                   .Where(x => x.Name.Contains("Repository"))
                                   .WithServiceAllInterfaces()
                                   .Configure(x =>
                                   {
                                       x.LifestyleTransient();
                                       x.IsFallback();
                                       x.Named(x.Implementation.FullName);
                                   }));

            container.Register(Classes.FromThisAssembly()
                                   .Where(x => x.Name.Contains("Startup"))
                                   .WithServiceAllInterfaces()
                                   .Configure(x =>
                                   {
                                       x.LifestyleSingleton();
                                       x.Named(x.Implementation.FullName);
                                   }));
        }
    }
}
