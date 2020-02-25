using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeWatcher.Models
{
    public class BikeStationBdx
    {
        private static readonly HttpClient client = new HttpClient();
        public int id { get; set; }
        public string name { get; set; }
        public int bike_count { get; set; }
        public int electric_bike_count { get; set; }
        public int bike_count_total { get; set; }
        public int slot_count { get; set; }
        public bool is_online { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        
    }
}
