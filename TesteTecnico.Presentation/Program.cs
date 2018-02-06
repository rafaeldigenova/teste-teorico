using TesteTecnico.Presentation.Windsor;
using Castle.Windsor;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico.Persistency.Mock;
using TesteTecnico.Application.Friends.Servicos;
using TesteTecnico.Domain.Amigos;

namespace TesteTecnico.Presentation
{
    public class Program
    {
        private static FriendsListService _friendsListService;
        private static NearestFriendsService _nearestFriendsService;

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var container = WindsorBootstrap.Start();

                await InitializePersistency(container);

                _friendsListService = container.Resolve<FriendsListService>();
                _nearestFriendsService = container.Resolve<NearestFriendsService>();

                bool visitAgain;

                do
                {
                    visitAgain = await VisitFriend();
                } while (visitAgain);

            }).GetAwaiter().GetResult();
        }

        private static async Task<bool> VisitFriend()
        {
            return await Task.Run(async () =>
            {
                var friends = await _friendsListService.GetFriendsList();

                Console.WriteLine($"{Environment.NewLine}Selecione um amigo para visitar!(para selecionar pressione o número que o representa)");

                friends.ForEach(friend =>
                {
                    Console.WriteLine($"  {friend.Id} - {friend.Nome}   - Latitude: {friend.Coordinates.Latitude}  - Longitude: {friend.Coordinates.Longitude}");
                });

                Friend selectedFriend = null;

                while (selectedFriend == null)
                {
                    var selectedFriendId = Console.ReadKey().KeyChar.ToString();

                    selectedFriend = friends.FirstOrDefault(x => x.Id.ToString() == selectedFriendId);

                    if (selectedFriend == null) {
                        Console.WriteLine($"{Environment.NewLine}Por favor, selecione um amigo entre os disponíveis na lista.");
                    }
                }

                var nearestFriends = await _nearestFriendsService.GetNearestFriends(selectedFriend);
                
                Console.WriteLine($"{Environment.NewLine}Os amigos mais próximos de {selectedFriend.Nome} são:");
                nearestFriends.ForEach(nearestFriend =>
                {
                    Console.WriteLine($"{nearestFriend.Nome} - distância: {selectedFriend.Coordinates.DistanceTo(nearestFriend.Coordinates)}");
                });
                
                Console.WriteLine($"{Environment.NewLine} Vai visitar outro amigo? s/n");

                var answer = Console.ReadKey().KeyChar;

                if (answer == 's')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        private static async Task InitializePersistency(IWindsorContainer container)
        {
            await Task.Run(async () =>
            {
                var peristenciaStartup = container.Resolve<PersistencyStartup>();

                if (peristenciaStartup != null)
                    await peristenciaStartup.Initialize().ConfigureAwait(false);
            });
        }
    }
}
