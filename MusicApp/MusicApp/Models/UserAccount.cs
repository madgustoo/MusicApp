using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class UserAccount
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage = "User name required.")]
        public string userName { get; set; }
        [Required(ErrorMessage = "password required.")]
        public string mdpUser { get; set; }
        [Compare("mdpUser", ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        public string mdpUserConfirm { get; set; }
        [Required(ErrorMessage = "Email required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string mail { get; set; }
    }
}