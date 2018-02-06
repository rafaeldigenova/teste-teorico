using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;

namespace TesteTecnico.Application.Installers
{
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                   .Where(x => x.Name.Contains("Service"))
                                   .WithServiceAllInterfaces()
                                   .Configure(x =>
                                   {
                                       x.LifestyleTransient();
                                       x.IsFallback();
                                       x.Named(x.Implementation.FullName);
                                   }));

     
        }
    }
}
