using BookReadingEvents.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookReadingEvents.Domain
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required]
        public UserType Role { get; set; }
    }
}
