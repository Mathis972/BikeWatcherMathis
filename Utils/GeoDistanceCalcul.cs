using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeWatcher.Utils
{
    public class GeoDistanceCalcul
    {
        public static double GetDistance(double lat1, double long1, double lat2, double long2)
        {
            return Math.Sqrt(Math.Pow((lat2 - lat1), 2) + Math.Pow((long2 - long1), 2));
        }
    }

}
