using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.Amigos;
using TesteTecnico.Domain.Amigos.Repositorios;

namespace TesteTecnico.Persistency.Mock.Amigos.Repositorios
{
    public class FriendRepository : BaseRepository<Friend> ,IFriendRepository
    {
        public FriendRepository()
            : base()
        {

        }
    }
}
