using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class userEditee
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string mdp_user { get; set; }
        public System.DateTime start_date { get; set; }
        public string Email { get; set; }
    }
}