using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{

    /* JSON Example: https://api.spotify.com/v1/albums/3vOgbDjgsZBAPwV2M3bNOj/tracks */
    // Make an endless request no pagination 

    public class AlbumTracksRootobject {
        public string href { get; set; }
        public List<Track> items { get; set; }
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

}
 