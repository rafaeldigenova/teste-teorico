using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.Amigos.Repositorios;
using TesteTecnico.Domain.Amigos;

namespace TesteTecnico.Application.Friends.Servicos
{
    public class NearestFriendsService
    {
        private readonly IFriendRepository _friendRepository;

        public NearestFriendsService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<List<Friend>> GetNearestFriends(Friend friend)
        {
            var friends = await _friendRepository.GetAllLazy();

            friends = friends.Where(x => x.Id != friend.Id).OrderBy(x => friend.Coordinates.DistanceTo(x.Coordinates)).Take(3);

            return friends.ToList();
        }
    }
}
