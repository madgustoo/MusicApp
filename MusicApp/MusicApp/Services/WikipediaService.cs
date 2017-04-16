using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using MusicApp.Models;
using Newtonsoft.Json;

namespace MusicApp.Services
{
    /// <summary>
    /// Gets the entire "intro section" of a Wikipedia article without the need of parsing 
    /// </summary>
    public class WikipediaService
    {
        private const string EXTRACT_URL = "https://en.wikipedia.org/w/api.php";

        public void GetArticleIntro(Artist artist) {
            // Use HTTP to Request
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })) {
                client.BaseAddress = new Uri(EXTRACT_URL);
                HttpResponseMessage response = client.GetAsync("?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=" + artist.name).Result;
                response.EnsureSuccessStatusCode();
                string outputString = response.Content.ReadAsStringAsync().Result;
                ArticleRootobject articleRootObject = JsonConvert.DeserializeObject<ArticleRootobject>(outputString);
                SetWikipediaInfo(articleRootObject, artist);
            }
        }

        private void SetWikipediaInfo(ArticleRootobject articleRootObject, Artist artist) {
            String pageId = articleRootObject.query.pages.Keys.First();
            artist.wikipediaProfile = "https://en.wikipedia.org/?curid=" + pageId;
            if (Int32.Parse(pageId) > 1){
                artist.wikipediaArticle = articleRootObject.query.pages[pageId].extract;
            }
        }

    }
}