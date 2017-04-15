using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{

    /* JSON Example: https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=eminem */

    public class ArticleRootobject {
        public string batchcomplete { get; set; }
        public Query query { get; set; }
    }

    public class Query {
        public Normalized[] normalized { get; set; }
        public Dictionary<string, Page> pages { get; set; }
    }

    public class Page {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }

    public class Normalized{
        public string from { get; set; }
        public string to { get; set; }
    }

}