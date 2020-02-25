using BikeWatcher.Controllers;
using BikeWatcher.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeWatcher.Models
{
    public class BikeStation : IComparable
    {
        
        public string number { get; set; }
        public string pole { get; set; }
        public string available_bikes { get; set; }
        public string code_insee { get; set; }
        public string lng { get; set; }
        public string availability { get; set; }
        public string availabilitycode { get; set; }
        public string etat { get; set; }
        public string startdate { get; set; }
        public string langue { get; set; }
        public string bike_stands { get; set; }
        public string last_update { get; set; }
        public string available_bike_stands { get; set; }
        public string gid { get; set; }
        public string titre { get; set; }
        public string status { get; set; }
        public string commune { get; set; }
        public string description { get; set; }
        public string nature { get; set; }
        public string bonus { get; set; }
        public string address2 { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string last_update_fme { get; set; }
        public string enddate { get; set; }
        public string name { get; set; }
        public string banking { get; set; }
        public string nmarrond { get; set; }

        public double distance;

        public BikeStation(BikeStationBdx bikeStation)
        {
            this.available_bikes = bikeStation.bike_count_total.ToString();
            this.lng = bikeStation.longitude;
            this.lat = bikeStation.latitude;
            this.bike_stands = bikeStation.slot_count.ToString();
            this.available_bike_stands = (bikeStation.slot_count - bikeStation.bike_count_total).ToString();
            this.name = bikeStation.name;
            this.gid = bikeStation.id.ToString();
        }
        public BikeStation()
        {

        }


        public int CompareTo(object obj)
        {
            BikeStation bikeStation = obj as BikeStation;

            distance = GeoDistanceCalcul.GetDistance(float.Parse(lat, CultureInfo.InvariantCulture), float.Parse(lng, CultureInfo.InvariantCulture), ListeController.lat, ListeController.lon);
            bikeStation.distance = GeoDistanceCalcul.GetDistance(float.Parse(bikeStation.lat, CultureInfo.InvariantCulture), float.Parse(bikeStation.lng, CultureInfo.InvariantCulture), ListeController.lat, ListeController.lon);

            if (bikeStation.distance == distance)
                return 0;

            return distance < bikeStation.distance ? -1 : 1;
        }

        public int SortByNumberAscending(string number1, string number2)
        {
            return Int32.Parse(number1).CompareTo(Int32.Parse(number2));
        }
    }
}
