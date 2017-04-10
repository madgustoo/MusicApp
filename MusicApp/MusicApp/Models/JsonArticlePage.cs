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
        public Pages pages { get; set; }
    }

    public class Pages { }

    public class Normalized{
        public string from { get; set; }
        public string to { get; set; }
    }

}