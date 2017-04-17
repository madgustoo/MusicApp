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

        private readonly string API_TOKEN = "uDtfeAgTKL3_YnOxco4NV6B-WVZAIGyuzgH6Yp07FiV9K9ZRFOAa3r3YoxHVG1Gg";
        private const string API_ENDPOINT = "http://api.genius.com";

        public GeniusService() { }

        public void SetTrackLyrics(string trackName) {
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })) {
                client.BaseAddress = new Uri(API_ENDPOINT);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AuthorizationToken ", API_TOKEN);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + API_TOKEN);
                HttpResponseMessage response = client.GetAsync("?q=" + trackName).Result;
                string outputString = response.Content.ReadAsStringAsync().Result;
            }    
        }

    }
}