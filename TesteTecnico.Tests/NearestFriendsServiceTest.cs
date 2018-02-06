using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TesteTecnico.Domain;
using TesteTecnico.Domain.Amigos.Repositorios;
using TesteTecnico.Domain.Amigos;
using TesteTecnico.Application.Friends.Servicos;

namespace TesteTecnico.Tests
{
    [TestClass]
    public class NearestFriendsServiceTest
    {
        [TestMethod]
        public void AssureReferenceFriendIsNotPartOfTheResult()
        {
            Task.Run(async () => {
                var mockFriendRepository = new Mock<IFriendRepository>();
                mockFriendRepository.Setup(x => x.GetAllLazy()).Returns(() => getDefaultFriendList());

                var friends = await getDefaultFriendList();
                var friend = friends.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                
                var nearestFriendsService = new NearestFriendsService(mockFriendRepository.Object);

                var nearestFriends = await nearestFriendsService.GetNearestFriends(friend);

                Assert.AreEqual(false, nearestFriends.All(x => x.Id != friend.Id));
            });
        }

        private Task<IQueryable<Friend>> getDefaultFriendList()
        {
            return Task.Run(() =>
            {
                var friendsList = new List<Friend>();

                for(var i = 0; i < 10; i ++)
                {
                    for(var j = 0; j < 10; j++)
                    {
                        friendsList.Add(new Friend((i * 10) + j, $"{i}_{j}", i, j));
                    }
                }

                return friendsList.AsQueryable();
            });
            
        }
    }
}
