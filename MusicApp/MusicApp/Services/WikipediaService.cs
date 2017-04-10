using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Services
{
    /// <summary>
    /// Gets the entire "intro section" of a Wikipedia article without the need of parsing 
    /// </summary>
    public class WikipediaService
    {
        private const string EXTRACT_URL = "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=";

        public string GetArticleIntro(string artistName) {
            // Use HTTP to Request
            return "";
        }

    }
}