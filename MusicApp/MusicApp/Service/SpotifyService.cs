using MusicApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;

namespace MusicApp.Service
{
    /// <summary>
    /// Requests from the Spotify API 
    /// Wrapper / API Client used: https://spotifywebapi.codeplex.com/
    /// </summary>
    public class SpotifyService {

        // MusicApp.Models.Item == Artist list
        public async Task<List<Item>> SearchArtist(string name) {
            var output = await SpotifyWebAPI.Artist.Search(name);
            string outputString = JsonConvert.SerializeObject(output.Items);
            // Deserialize the JSON string into a List of Item[an Artist is an item] 
            List<Item> searchList = JsonConvert.DeserializeObject<List<Item>>(outputString);
            return searchList;
        }
        
    }
}