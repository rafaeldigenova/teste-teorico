using System;
using TesteTecnico.Infrastructure.Dominio;
using TesteTecnico.Domain.Coordinates;

namespace TesteTecnico.Domain.Amigos
{
    public class Friend : EntityBase
    {
        public Coordinate Coordinates { get; set; }
        public string Nome { get; set; }

        public Friend()
        {
            Coordinates = new Coordinate();
        }

        public Friend(int id, string nome, int latitude, int longitude)
            : this()
        {
            Id = id;
            Nome = nome;
            Coordinates.Latitude = latitude;
            Coordinates.Longitude = longitude;
        }

        public override void Update(EntityBase entity)
        {
            if(!(entity is Friend))
                throw new ArgumentException("To update a existing friend, a Friend entity must be used");

            var friend = (Friend)entity;

            Coordinates.Latitude = friend.Coordinates.Latitude;
            Coordinates.Longitude = friend.Coordinates.Longitude;
            Nome = friend.Nome;
        }
    }
}
