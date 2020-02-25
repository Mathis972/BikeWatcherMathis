using BikeWatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeWatcher.Repository
{
    public class RepositoryBikeStations
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<List<BikeStation>> ProcessBikeStations(string apiURL)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(apiURL);
            var deserializedJSON = await JsonSerializer.DeserializeAsync<RootObject>(await streamTask);
            return deserializedJSON.values;
        }
        public static async Task<List<BikeStation>> ProcessBikeStationsBdx(string apiURL)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(apiURL);
            var deserializedJSON = await JsonSerializer.DeserializeAsync<List<BikeStationBdx>>(await streamTask);
            var listBdx = new List<BikeStation>();
            foreach (var stationBdx in deserializedJSON)
            {
                var station = new BikeStation(stationBdx);
                listBdx.Add(station);
            }

            return listBdx;
        }
    }
}
