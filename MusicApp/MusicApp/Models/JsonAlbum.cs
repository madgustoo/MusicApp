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

        // Info for ONE album object https://api.spotify.com/v1/albums/0sNOF9WDwhWunNAHPD3Baj
        public string label { get; set; }
        public string release_date { get; set; }
        public List<Copyright> copyrights { get; set; }
    }

    public class Copyright {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Artist {
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        // Related artist struff
        public List<string> genres { get; set; }
        // Profile stuff
        public List<Image> images { get; set; }
        public string youtubeProfile { get; set; } // url
        public string deezerProfile { get; set; } // url
        public string wikipediaProfile { get; set; } // url
        public string wikipediaArticle { get; set; } // url
    }
}