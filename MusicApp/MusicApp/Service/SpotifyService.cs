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
        public async Task<Artists> SearchArtist(string name, int offset) {
            var output = (Object) null;
            if (offset > 0) {
                // At the end: limit and offset
                output = await SpotifyWebAPI.Artist.Search(name, "", "", "", "", 20, offset);
            } else {
                output = await SpotifyWebAPI.Artist.Search(name);
            }
            string outputString = JsonConvert.SerializeObject(output);
            // Deserialize the JSON string into a Artists Object / Item[an Artist is an item] 
            Artists searchResult = JsonConvert.DeserializeObject<Artists>(outputString);
            return searchResult;
        }
    
    }
}