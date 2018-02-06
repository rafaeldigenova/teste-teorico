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
using TesteTecnico.Domain.Coordinates;

namespace TesteTecnico.Tests
{
    [TestClass]
    public class CoordinatesTest
    {
        [TestMethod]
        public void AssureThatDistanceToResultIsAsExpected()
        {
            var coordinateBase = new Coordinate(5, 5);

            var distance = coordinateBase.DistanceTo(new Coordinate(4, 5));
            Assert.AreEqual(Math.Round(distance, 1), 1);

            distance = coordinateBase.DistanceTo(new Coordinate(6, 5));
            Assert.AreEqual(Math.Round(distance, 1), 1);

            distance = coordinateBase.DistanceTo(new Coordinate(5, 4));
            Assert.AreEqual(Math.Round(distance, 1), 1);

            distance = coordinateBase.DistanceTo(new Coordinate(5, 6));
            Assert.AreEqual(Math.Round(distance, 1), 1);

            distance = coordinateBase.DistanceTo(new Coordinate(5, 5));
            Assert.AreEqual(Math.Round(distance, 1), 0);

            distance = coordinateBase.DistanceTo(new Coordinate(2, 1));
            Assert.AreEqual(Math.Round(distance, 1), 5);

            distance = coordinateBase.DistanceTo(new Coordinate(8, 9));
            Assert.AreEqual(Math.Round(distance, 1), 5);
        }
    }
}
