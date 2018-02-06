using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TesteTecnico.Persistency.Mock.Amigos;

namespace TesteTecnico.Persistency.Mock
{
    public class PersistencyStartup
    {
        private readonly FriendsStartup _friendsStartup;

        public PersistencyStartup(FriendsStartup friendsStartup)
        {
            _friendsStartup = friendsStartup;
        }

        public async Task Initialize()
        {
            await _friendsStartup.Initialize().ConfigureAwait(false);
        }

    }
}
