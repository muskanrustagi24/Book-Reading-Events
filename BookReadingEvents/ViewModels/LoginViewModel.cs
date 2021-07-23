using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReadingEvents.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="The email is required!!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="The Password is required!") , MinLength(8 , ErrorMessage ="The password should be atleast of length 8")]
        public string Password { get; set; }
    }
}