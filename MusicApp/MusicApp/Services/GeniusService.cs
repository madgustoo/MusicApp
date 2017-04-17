using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    /// <summary>
    /// Requests from the Genius API 
    /// </summary>
    public class GeniusService {

        private readonly string API_TOKEN = "EfSAEGe8_3sBG9MvZpWuXztbqGZJDE80ZerUPQZOlG_v9xF2w3Z0eIbV1D2PNtzm";
        private const string API_ENDPOINT = "http://api.genius.com";

        public GeniusService() { }

        public void SetTrackLyrics(string trackName) {
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })) {
                client.BaseAddress = new Uri(API_ENDPOINT);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AuthorizationToken ", API_TOKEN);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", API_TOKEN);
                HttpResponseMessage response = client.GetAsync("?q" + trackName).Result;
                string outputString = response.Content.ReadAsStringAsync().Result;
                //ArticleRootobject articleRootObject = JsonConvert.DeserializeObject<ArticleRootobject>(outputString);
            }    
        }

    }
}