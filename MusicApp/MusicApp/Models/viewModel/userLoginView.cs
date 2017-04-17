using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models.viewModel
{
    public class userLoginView
    {
        [Required(ErrorMessage = "User name required.")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "password required.")]
        public string mdp_user { get; set; }
    }
}