﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    /*JSON Example: https://api.spotify.com/v1/search?q=pnl&type=artist */

    public class Rootobject {
        public Artists artists { get; set; }
    }

    public class Artists {
        public string href { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    // JSON Artist Object
    public class Item {
        public External_Urls external_urls { get; set; }
        public Followers followers { get; set; }
        public List<string> genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls {
        public string spotify { get; set; }
    }

    public class Followers {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class Image {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }
}