using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.Amigos.Repositorios;
using TesteTecnico.Domain.Amigos;

namespace TesteTecnico.Persistency.Mock.Amigos
{
    public class FriendsStartup : StartupBase
    {
        private struct Coordinates
        {
            public int Longitude { get; set; }
            public int Latitude { get; set; }
        }

        private readonly List<string> friendsName = new List<string>
            { "Miguel", "Arthur", "Davi", "Bernardo", "Heitor", "Gabriel", "Pedro", "Lorenzo", "Lucas", "Matheus",
              "Alice", "Sophia", "Laura", "Valentina", "Helena", "Isabela", "Manuela", "Júlia", "Luíza", "Ana"};
        private List<Coordinates> usedCoordinates = new List<Coordinates>();
        private int latitude, longitude;
        private Random _random;


        private readonly IFriendRepository _friendRepository;

        public FriendsStartup(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
            _random = new Random();
        }

        public override async Task Initialize()
        {
            await Task.Run(() =>
            {
                for(var i = 0; i < 10; i++)
                {
                    _friendRepository.Add(GenerateRandomFriend(i));
                }
            });
        }

        private Friend GenerateRandomFriend(int id) {
            var name = friendsName.OrderBy(x => Guid.NewGuid()).First();

            do
            {
                latitude = _random.Next(100);
                longitude = _random.Next(100);
            } while (usedCoordinates.Any(x => x.Latitude == latitude && x.Longitude == longitude));

            usedCoordinates.Add(new Coordinates() { Latitude = latitude, Longitude = longitude });

            return new Friend(id, name, latitude, longitude);
        }
    }
}

