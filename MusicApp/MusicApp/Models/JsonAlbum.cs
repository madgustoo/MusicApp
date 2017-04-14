using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    /*JSON Example: https://api.spotify.com/v1/artists/3NH8t45zOTqzlZgBvZRjvB/albums/ */

    public class AlbumRootObject {
        public string href { get; set; }
        public List<Album> items { get; set; }
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class Album {
        public string album_type { get; set; }
        public List<Artist> artists { get; set; }
        public string[] available_markets { get; set; }
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Artist {
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        // Profile stuff
        public List<Image> images { get; set; }
        public string youtubeProfile { get; set; }
        public string deezerProfile { get; set; }
        public string wikipediaProfile { get; set; }
    }
}