using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnico.Domain.Coordinates
{
    public class Coordinate
    {
        public int Longitude { get; set; }
        public int Latitude { get; set; }

        public Coordinate()
        {

        }

        public Coordinate(int latitude, int longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double DistanceTo (Coordinate target)
        {
            var baseRad = Math.PI * Latitude / 180;
            var targetRad = Math.PI * target.Latitude / 180;
            var theta = Longitude - target.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;

            return dist;
        }
    }
}
