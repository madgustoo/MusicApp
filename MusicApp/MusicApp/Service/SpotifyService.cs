using MusicApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MusicApp.Service
{
    public class SpotifyService
    {
        /* Search endpoint */
        private string url = "https://api.spotify.com/v1/search";

        public async Task<List<Artist>> GetArtistsAsync() {
            url += "?q='em'&type='artist'";
            using (HttpClient httpClient = new HttpClient()) {
                return JsonConvert.DeserializeObject<List<Artist>>(
                    await httpClient.GetStringAsync(url)
                );
            }
        }

    }
}