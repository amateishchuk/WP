using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WP.Models
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
        [MinLength(5, ErrorMessage = "Username must contains at least 5 symbols")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Input valid email.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password must be longer")]
        public string Password { get; set; }        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confim your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords are different.")]        
        public string ConfirmPassword { get; set; }
    }
}