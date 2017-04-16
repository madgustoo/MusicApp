using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models.viewModel
{
    public class userRegisterView
    {
        [Key]
        public int user_Id { get; set; }
        [Required(ErrorMessage = "User name required.")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "password required.")]
        public string mdp_user { get; set; }
        [Compare("mdp_user", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string mdpUserConfirm { get; set; }
        [Required(ErrorMessage = "Email required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
    }
}