using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    /* JSON Example: https://api.spotify.com/v1/artists/3NH8t45zOTqzlZgBvZRjvB/related-artists */

    public class RelatedArtistRootObject {
        public List<Artist> artists { get; set; }
    }

}