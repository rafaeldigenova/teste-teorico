using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.Amigos.Repositorios;
using TesteTecnico.Domain.Amigos;

namespace TesteTecnico.Application.Friends.Servicos
{
    public class FriendsListService
    {
        private readonly IFriendRepository _friendRepository;

        public FriendsListService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<List<Friend>> GetFriendsList()
        {
            var friends = await _friendRepository.GetAllLazy();

            return friends.ToList();
        }
    }
}
