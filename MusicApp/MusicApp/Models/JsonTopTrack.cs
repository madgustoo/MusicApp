using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Models
{

    /* JSON Exanple: https://api.spotify.com/v1/artists/3NH8t45zOTqzlZgBvZRjvB/top-tracks?country=US */

    public class TopTrackRootobject {
        public List<Track> tracks { get; set; }
    }

    public class Track {
        public Album album { get; set; }
        public List<Artist> artists { get; set; }
        public List<string> available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool _explicit { get; set; }
        public External_Ids external_ids { get; set; }
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string previewUrl { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public string youtubeUrl { get; set; }
    }

    public class External_Ids  {
        public string isrc { get; set; }
    }

}
